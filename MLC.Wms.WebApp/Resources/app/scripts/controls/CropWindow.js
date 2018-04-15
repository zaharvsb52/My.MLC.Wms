/**
 * Licence:
 * @author Thomas Lauria
 * http://www.thomas-lauria.de
 */
Ext.define('MLC.wms.controls.CropWindow', {
    requires: [
        'Ext.Window',
        'MLC.wms.controls.CropControl'
    ],
    extend: 'Ext.Window',
    cropData: null,
    imageUrl: undefined,
    retImageUrl: undefined,

    title: 'Обрезать',
    maxHeight: 640,
    maxWidth: 800,
    minWidth: 200,
    minHeight: 200,
    resizable: false,
    modal: true,
    initComponent: function () {
        var me = this;
        me.fbar = {
            xtype: 'toolbar',
            items: [
                {
                    xtype: 'button',
                    text: 'Отмена',
                    itemId: 'cancelButton'
                },
                {
                    xtype: 'button',
                    text: 'Обрезать',
                    itemId: 'saveButton'
                }
            ]
        };
        // I am using an image preloader here, for getting the initial height and width
        me.callParent(arguments);
        var imgLoad = new Image();
        imgLoad.onload = (function () {
            this.setSize(imgLoad.width + 100, imgLoad.height + 100);
            var crop = new MLC.wms.controls.CropControl({
                src: this.imageUrl,
                width: imgLoad.width,
                height: imgLoad.height,
                maxHeight: me.maxHeight,
                maxWidth: me.maxWidth,
                minWidth: imgLoad.width,
                minHeight: imgLoad.height,
                quadratic: true
            });
            crop.on('changeCrop', function (foo, x) { this.cropData = x; }, me);
            me.add(crop);
            me.center();
        }).bind(me);
        imgLoad.src = me.imageUrl;

        // handler for the buttons
        me.down('#cancelButton').on('click', me.close, me);
        me.down('#saveButton').on('click', me.saveCrop, me);
    },
    saveCrop: function () {
        var meImgCropData = this;
        var canvas = document.createElement('canvas');
        var ctx = canvas.getContext("2d");
        var imgSrc = this.items.items[0].src;

        var image = new Image();
        image.onload = function () {

            var xData = image.width > meImgCropData.maxWidth ? (meImgCropData.cropData.x / meImgCropData.width) * image.width : meImgCropData.cropData.x,
                yData = image.height > meImgCropData.maxHeight ? (meImgCropData.cropData.y / meImgCropData.height) * image.height : meImgCropData.cropData.y,
                widthData = image.width > meImgCropData.maxWidth ? image.width * (meImgCropData.cropData.width / meImgCropData.width) : meImgCropData.cropData.width,
                heightData = image.height > meImgCropData.maxHeight ? image.height * (meImgCropData.cropData.height / meImgCropData.height) : meImgCropData.cropData.height;

            canvas.width = image.width > widthData ? widthData : image.width;
            canvas.height = image.height > heightData ? heightData : image.height;

            ctx.drawImage(image,
                xData,
                yData,
                widthData,
                heightData,
                0,
                0,
                canvas.width,
                canvas.height);
            meImgCropData.saveCropCallback(canvas);
        };
        image.src = imgSrc;
    },

    saveCropCallback: function (args) {
        var retImageUrl = args.toDataURL();

        this.fireEvent('imageCroped', this, retImageUrl);
        this.close();
    }
});