# Using Qplayer in a webview
First you need to turn on javascript and DOM in your webview
```
webview1.Settings.JavaScriptEnabled = true;
webview1.Settings.DomStorageEnabled = true;
if (Build.VERSION.SdkInt > BuildVersionCodes.JellyBean)
{
	webview1.Settings.MediaPlaybackRequiresUserGesture = false;
}
```
Create your html page afterwards and we are done.

HTML sample page is available in LoadPlayer.cs file