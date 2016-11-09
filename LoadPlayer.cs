 public static string GetPlayerHtmlV2(string videoid, string videoUrl, string cover, string title, string vasttag)
        {

            var mngr = Application.Context.GetSystemService(Context.TelephonyService) as TelephonyManager;


            var DeviceId = mngr?.DeviceId;




            var link = "http://bin.qplayer.io/stable/qplayer.js";

            //            #if (DEBUG)
            //                        link = "http://qplayer.qmeryserver.ir/js/bin-debug/qplayer.js?rnd";
            //#endif
            //             link = "http://bin.qplayer.io/stable/qplayer.js";
            #region style
            var style = @"
                                        html,body{ width:100%;height:100% }
                                        .qp-skin-mobile * {
                                          font-family: iransans !important;
                                        }
                                        .qp-skin-mobile .qp-icon {
                                          font-family: qp-icons !important;
                                        }
                                        .qp-skin-mobile .qp-background-color {
                                          background-color: rgba(0, 0, 0, 0.6);
                                        }
                                        .qp-skin-mobile:hover .qp-display-icon-container {
                                          border: 1px solid #333;
                                          background: rgba(0, 0, 0, 0.6) !important;
                                        }
                                        .qp-skin-mobile .qp-controlbar {
                                          transition: all 0.3s ease-out;
                                          border-top: none;
                                          height: 2.5em;
                                          background: rgba(0, 0, 0, 0.6);
                                        }
                                        .qp-skin-mobile .qp-group {
                                          display: table-cell;
                                          vertical-align: middle;
                                        }
                                        .qp-skin-mobile .qp-playlist {
                                          max-height: 11em;
                                          min-height: 4.5em;
                                          overflow-x: hidden;
                                          overflow-y: scroll;
                                          width: calc(96%);
                                          background-color: rgba(0, 0, 0, 0.8);
                                        }
                                        .qp-skin-mobile .qp-playlist-container {
                                          left: -43%;
                                          background-color: rgba(0, 0, 0, 0.8);
                                          z-index: 1;
                                          /* li list option */
                                          /* play icon is always active */
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-option {
                                          border-bottom: 1px solid #444;
                                          /* Playlist items are black when active, or hovered */
                                          /* Number color when li is hovered */
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-option:hover,
                                        .qp-skin-mobile .qp-playlist-container .qp-option.qp-active-option {
                                          background-color: black;
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-option:hover .qp-label {
                                          color: #23b577;
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-icon-playlist {
                                          margin-left: 0;
                                          visibility: hidden;
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-label .qp-icon-play {
                                          color: #23b577;
                                        }
                                        .qp-skin-mobile .qp-playlist-container .qp-label .qp-icon-play:before {
                                          padding-left: 0;
                                        }
                                        .qp-skin-mobile .qp-tooltip-title {
                                          background-color: #000;
                                          border-bottom: 1px solid #444;
                                          text-align: left;
                                          padding-left: .7em;
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-text {
                                          font-size: .75em;
                                          font-style: normal;
                                          font-weight: 400;
                                          text-align: center;
                                          font-variant: normal;
                                          font-stretch: normal;
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-button-color {
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-toggle {
                                          color: #23b577;
                                        }
                                        .qp-skin-mobile .qp-toggle.qp-off {
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-controlbar .qp-icon:before,
                                        .qp-skin-mobile .qp-text-elapsed,
                                        .qp-skin-mobile .qp-text-duration {
                                          padding: 0 .7em;
                                        }
                                        .qp-skin-mobile .qp-controlbar .qp-icon-prev:before {
                                          padding-right: 0.25em;
                                        }
                                        .qp-skin-mobile .qp-controlbar .qp-icon-playlist:before {
                                          padding: 0 0.45em;
                                        }
                                        .qp-skin-mobile .qp-controlbar .qp-icon-next:before {
                                          padding-left: 0.25em;
                                        }
                                        .qp-skin-mobile .qp-icon-prev,
                                        .qp-skin-mobile .qp-icon-next {
                                          font-size: .7em;
                                        }
                                        .qp-skin-mobile .qp-icon-prev:before {
                                          border-left: 1px solid #666;
                                        }
                                        .qp-skin-mobile .qp-icon-next:before {
                                          border-right: 1px solid #666;
                                        }
                                        .qp-skin-mobile .qp-icon-display {
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-icon-display:before {
                                          padding-left: 0;
                                        }
                                        .qp-skin-mobile .qp-display-icon-container {
                                          border-radius: 50%;
                                          padding: 0 .3em;
                                          border: 1px solid #333;
                                        }
                                        .qp-skin-mobile .qp-display-icon-container .qp-icon-display {
                                          font-size: 1.3em;
                                        }
                                        .qp-skin-mobile .qp-rail {
                                          background-color: #384154;
                                          box-shadow: none;
                                          position: absolute;
                                          cursor: pointer;
                                        }
                                        .qp-skin-mobile .qp-buffer {
                                          background-color: #666F82;
                                          position: absolute;
                                          cursor: pointer;
                                        }
                                        .qp-skin-mobile .qp-progress {
                                          background: #23b577;
                                          position: absolute;
                                          cursor: pointer;
                                        }
                                        .qp-skin-mobile .qp-knob {
                                          background: #23b577 !important;
                                          transition: transform 0.2s ease-out, border 0.2s ease-out;
                                          border: 5px solid #fff;
                                          border-radius: 50%;
                                          width: 10px;
                                          height: 10px;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal {
                                          display: inline-block;
                                          position: relative;
                                          line-height: 2em;
                                          vertical-align: middle;
                                          cursor: pointer;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal .qp-slider-container {
                                          height: 0.95em;
                                          margin-top: 6px;
                                          background: 0 0;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal.qp-slider-volume {
                                          display: none;
                                          background: transparent;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal .qp-rail,
                                        .qp-skin-mobile .qp-slider-horizontal .qp-buffer,
                                        .qp-skin-mobile .qp-slider-horizontal .qp-progress {
                                          height: .2em;
                                          border-radius: 0;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal .qp-knob {
                                          top: -0.2em;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal .qp-cue {
                                          width: .3em;
                                          height: .3em;
                                          background-color: #fff;
                                          border-radius: 50%;
                                          top: -0.05em;
                                        }
                                        .qp-skin-mobile .qp-slider-horizontal .qp-cue:after {
                                          width: .3em;
                                          height: .3em;
                                          background-color: #fff;
                                          border-radius: 50%;
                                        }
                                        .qp-skin-mobile .qp-slider-vertical {
                                          width: .75em;
                                          height: 4em;
                                          bottom: 0;
                                          position: absolute;
                                          padding: 1em;
                                        }
                                        .qp-skin-mobile .qp-slider-vertical .qp-rail,
                                        .qp-skin-mobile .qp-slider-vertical .qp-buffer,
                                        .qp-skin-mobile .qp-slider-vertical .qp-progress {
                                          width: .2em;
                                          bottom: 0;
                                          height: 100%;
                                        }
                                        .qp-skin-mobile .qp-menu,
                                        .qp-skin-mobile .qp-volume-tip {
                                          bottom: 0.15em;
                                        }
                                        .qp-skin-mobile .qp-menu,
                                        .qp-skin-mobile .qp-time-tip,
                                        .qp-skin-mobile .qp-volume-tip {
                                          position: relative;
                                          left: -50%;
                                          border: 1px solid #000;
                                          margin: 0;
                                        }
                                        .qp-skin-mobile .qp-volume-tip {
                                          width: 100%;
                                          height: 100%;
                                          display: block;
                                          left: -45%;
                                          padding-bottom: .7em;
                                          border: 1px solid #333;
                                        }
                                        .qp-skin-mobile .qp-text-duration {
                                          color: #666F82;
                                        }
                                        .qp-skin-mobile .qp-controlbar-right-group {
                                          white-space: nowrap;
                                        }
                                        .qp-skin-mobile .qp-controlbar-right-group .qp-icon-tooltip:before,
                                        .qp-skin-mobile .qp-controlbar-right-group .qp-icon-inline:before {
                                          border-left: 1px solid #666;
                                        }
                                        .qp-skin-mobile .qp-controlbar-right-group .qp-icon-inline:first-child:before {
                                          border: none;
                                        }
                                        .qp-skin-mobile .qp-controlbar-center-group {
                                          width: 100%;
                                          padding: 0 .25em;
                                        }
                                        .qp-skin-mobile .qp-controlbar-center-group .qp-text-alt {
                                          color: red;
                                          margin-left: 50% !important;
                                          font-size: 15px;
                                          top: -10px;
                                          padding: 0;
                                          display: none;
                                        }
                                        .qp-skin-mobile .qp-controlbar-center-group .qp-text-alt:before {
                                          content: 'زنده';
                                        }
                                        .qp-skin-mobile .qp-dock .qp-dock-button {
                                          border-radius: 50%;
                                          border: 1px solid #333;
                                        }
                                        .qp-skin-mobile .qp-dock .qp-overlay {
                                          border-radius: 2.5em;
                                        }
                                        .qp-skin-mobile .qp-icon-tooltip .qp-active-option {
                                          background-color: #23b577;
                                          color: #fff;
                                        }
                                        .qp-skin-mobile .qp-icon-volume {
                                          min-width: 2.6em;
                                        }
                                        .qp-skin-mobile .qp-time-tip,
                                        .qp-skin-mobile .qp-menu,
                                        .qp-skin-mobile .qp-volume-tip,
                                        .qp-skin-mobile .qp-skip {
                                          border: 1px solid #333;
                                        }
                                        .qp-skin-mobile .qp-time-tip {
                                          padding: 0.2em;
                                          bottom: 1.3em;
                                          line-height: 1em;
                                          pointer-events: none;
                                          text-align: center;
                                          font-family: inherit;
                                          color: #aaa;
                                          border: 4px solid #000;
                                        }
                                        .qp-skin-mobile .qp-menu,
                                        .qp-skin-mobile .qp-volume-tip {
                                          bottom: .24em;
                                        }
                                        .qp-skin-mobile .qp-title {
                                          transform: translateY(150%) scaleX(1.2);
                                          opacity: 0;
                                          transition: all 0.3s ease-out;
                                          direction: rtl;
                                          text-align: center;
                                          background: transparent;
                                          bottom: 0;
                                          top: initial;
                                          font-size: 1.1em;
                                          padding: 0 0.5em;
                                        }
                                        .qp-skin-mobile .qp-skip {
                                          padding: 0.4em;
                                          border-radius: 1.75em;
                                        }
                                        .qp-skin-mobile .qp-skip .qp-text,
                                        .qp-skin-mobile .qp-skip .qp-icon-inline {
                                          color: #fff;
                                          line-height: 1.75em;
                                          font-size: 0.7em;
                                        }
                                        .qp-skin-mobile .qp-skip.qp-skippable:hover .qp-text,
                                        .qp-skin-mobile .qp-skip.qp-skippable:hover .qp-icon-inline {
                                          color: #23b577;
                                        }
                                        .qp-skin-mobile.qp-state-idle .qp-title {
                                          opacity: 1;
                                          transform: scaleX(1);
                                        }
                                        .qp-skin-mobile.qp-state-idle .qp-title .qp-title-primary {
                                          font-size: 1.2em;
                                        }
                                        .qp-skin-mobile .qp-title-primary,
                                        .qp-skin-mobile .qp-title-secondary {
                                          max-width: 75%;
                                          width: auto;
                                          min-height: 0;
                                          overflow: hidden;
                                          padding: .5em 15px;
                                          background-color: rgba(0, 0, 0, 0.5);
                                          margin: 0 0 0.5em 0;
                                        }
                                        .qp-skin-mobile .qp-title-secondary {
                                          clear: both;
                                        }
                                        .qp-skin-mobile.qp-direction-rtl .qp-title-secondary,
                                        .qp-skin-mobile.qp-direction-rtl .qp-title-primary {
                                          direction: rtl;
                                          text-align: right;
                                          position: relative !important;
                                          float: right !important;
                                          top: 0;
                                        }
                                        .qp-skin-mobile .qp-slider-time {
                                          background-color: transparent;
                                        }
                                        .qp-skin-mobile.qp-flag-touch .qp-controlbar .qp-icon:before,
                                        .qp-skin-mobile.qp-flag-touch .qp-text-elapsed,
                                        .qp-skin-mobile.qp-flag-touch .qp-text-duration {
                                          padding: 0 .35em;
                                        }
                                        .qp-skin-mobile.qp-flag-touch .qp-controlbar .qp-icon-prev:before {
                                          padding: 0 0.125em 0 0.7em;
                                        }
                                        .qp-skin-mobile.qp-flag-touch .qp-controlbar .qp-icon-next:before {
                                          padding: 0 0.7em 0 0.125em;
                                        }
                                        .qp-skin-mobile.qp-flag-touch .qp-controlbar .qp-icon-playlist:before {
                                          padding: 0 .225em;
                                        }
                                        .qp-skin-mobile .qp-state-idle .qp-icon-display:before {
                                          margin-left: -5px;
                                        }
                                        .qp-skin-mobile .qp-state-idle .qp-title {
                                          transform: translateY(0) scaleX(1);
                                          opacity: 1;
                                        }
                                        .qp-skin-mobile .qp-state-idle .qp-display-icon-container {
                                          padding: 0 0 0 0.5em;
                                        }
                                        .qp-skin-mobile .qp-states-place .qp-states-place-live {
                                          display: none;
                                        }
                                        .qp-skin-mobile .qp-loader-triggel {
                                          border-color: #23b577 transparent transparent !important;
                                        }
                                        .qp-skin-mobile .qp-box {
                                          border-top: 5px solid #23b577;
                                        }
                                        .qp-skin-mobile .qp-rightclick {
                                          border: 1px solid #23b577;
                                        }
                                        .qp-skin-mobile .qp-rightclick .qp-icon {
                                          color: #23b577;
                                        }
                                        .qp-title-more-detail {
                                         display: none!important;
                                         }
                                         .qp-ads-banner-nonelinear{
                                            botton:40%;
                                        }

                                    ".Replace("#23b577", ToolsClass.HexConverter(Android.App.Application.Context.Resources.GetColor(Resource.Color.MainColor)));
            #endregion

            string temp = @"<html>
                                <head>
                            "  + @"

                                        <title>  </title>

                                        <style>
                                                " + style + @"
                                        </style>
                                </head>
                                <body>
                                        <div id=""myElement""></div>
                                            <script type=""text/javascript"" src=""" + link + @""" charset=""UTF-8""></script>
                                            <script>
                                                document.getElementsByTagName('body')[0].style.margin = ""0px"";


                                          
                                                var playerInstance = qplayer(""myElement"");
                                                playerInstance.setup({
                                                            skin:'mobile',
                                                            playlist: [
                                                             {
                                                                sources:[
                                                                        {
                                                                            file: """ + videoUrl + @""",}
				                                                    ],
        		                                                    image: """ + cover + @""",
                                                                     vid: """ + videoid + @"""
                                                                }
                                                             ]

		                                            ,primary: ""auto""
                                                    ,HLSMSE:{
                                                        quality:true
                                                        //,maxBufferLength:10
                                                    }
                                                    ,advertising:{
			                                            schedule:""" + vasttag + @""",
                                                        admessage: ""XX ثانیه تا پایان آگهی بازرگانی "",
                                                        skipmessage: ""XX ثانیه"",
                                                        skiptext: ""رد کردن"",
                                                        cuetext: ""آگهی بازرگانی"",
                                                        loadOnTime:true,
                                                        'gaa':[]
		                                            }
                                                    ,ga:
                                                            {
                                                                mediaid:""" + videoid + @""",
                                                                ""label"":""app-" + title + @"""

                                                    }
		                                            ,qa:
                                                            {
                                                                uuid: """ + DeviceId + @""",
                                                                sid: """ + "app - " + videoid + @"""
                                                                //sendtype:""post"",
                                                                //timeseperator:20
                                                                ////console.log(this.getContainer().getAttribute(""class""));
        },
                                                        width:""100%"",
                                                        height:""100%""
                                                        });

                                                    //playerInstance.resize(""100%"",window.innerHeight);
                                                    //window.onresize = function(){
                                                      //          playerInstance.resize(""100%"", window.innerHeight);
                                                        //    };
                                                    playerInstance.on('fullscreen', function(e) { CSharp.FullScreen(); })
                                                    playerInstance.on('pause', function(e) { CSharp.PlayPauseEvent('pause'); })
                                                    playerInstance.on('play', function(e) { CSharp.PlayPauseEvent('play'); })
                                                    playerInstance.on('ready', function(e) { console.debug('jqPlayer : ready'); console.debug(playerInstance.version); CSharp.JwReady(); })
                                                    //playerInstance.on('adClick', function(e) {playerInstance.play(false);CSharp.PlayPauseEvent('ad');CSharp.title(e.tag);})
                                            </script>
                                </body>
                            </html> ";
            if (string.IsNullOrEmpty(videoUrl) || string.IsNullOrEmpty(cover)) return "";
            var stringdf = temp;// string.Format(temp, videoUrl ?? "", cover ?? "");
            return stringdf;
        }