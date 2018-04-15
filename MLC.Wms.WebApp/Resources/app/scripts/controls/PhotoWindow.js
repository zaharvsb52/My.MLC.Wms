Ext.define('MLC.wms.controls.PhotoWindow', {
    requires: [
        'Ext.Window',
        'MLC.wms.controls.CropControl'
    ],

    extend: 'Ext.Window',
    cropData: null,
    imageUrl: undefined,
    retImageUrl: undefined,
    title: 'Фото',
    maxHeight: 640,
    maxWidth: 800,
    minWidth: 200,
    minHeight: 200,
    modal: true,

    initComponent: function() {
        var me = this,
            getUsrMd = Ext.bind(navigator.getUserMedia ||
                /* chrome и safari           */
                navigator.webkitGetUserMedia ||
                /* firefox                   */
                navigator.mozGetUserMedia ||
                /* ie                        */
                navigator.msGetUserMedia, navigator);

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
                    text: 'Сохранить',
                    itemId: 'photoButton'
                }
            ]
        };

        /* обьект, который переводит MediaStream в Blob */
        var wUrl = window.URL || window.webkitURL;

        /* запрашиваем доступ к веб-камере */
        if (getUsrMd) {
            getUsrMd({ audio: false, video: true },
                function(pLocalMediaStream) {
                    /*
         * создаём элемент Video,
         * в который помещаем картинку с веб-камеры\
         */
                    var lVideo = new Ext.Component({
                        width: 640,
                        height: 480,
                        listeners: {
                            resize: function () {
                                me.center();
                            }
                        },
                        autoEl: {
                                tag: 'video',
                                id: 'cameraForFoto',
                                autoplay: true,
                                src: wUrl.createObjectURL(pLocalMediaStream)
                        }
                    });

                    me.add(lVideo);
                },
                function(pError) { /* если возникла ошибка - выводим её */
                    if (pError.name === 'DevicesNotFoundError' && !pError.message)
                        Ext.Error.raise('Camera is not available');

                    Ext.Error.raise(pError);
                });

            me.callParent(arguments);

            me.down('#cancelButton').on('click', me.close, me);
            me.down('#photoButton').on('click', me.takePhoto, me);
        }
    },

    takePhoto: function() {
        var live = Ext.dom.Query.select('video',this.el.dom)[0],
            canvas = document.createElement('canvas'),
            ctx = canvas.getContext("2d");

        canvas.width = live.clientWidth;
        canvas.height = live.clientHeight;
        ctx.drawImage(live, 0, 0, canvas.width, canvas.height);

        var retImageUrl = canvas.toDataURL();
        this.fireEvent('photoReady', this, retImageUrl);
        this.close();
    },

    show: function () {
        var me = this;
        me.callParent(arguments);
        me.center();
    }
});