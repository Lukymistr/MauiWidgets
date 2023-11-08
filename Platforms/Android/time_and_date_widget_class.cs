using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;
using Color = Android.Graphics.Color;

namespace MauiWidgets.Platforms.Android {

    [BroadcastReceiver(Label = "Time and date", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/time_and_date_widget_provider")]
    [Service(Exported = true)]

    internal class time_and_date_widget_class : AppWidgetProvider {
        private System.Timers.Timer timer;

        /// <summary>
        /// Něco jako konstruktor, povětšinou 2 první řádky zůstávají stejné.
        /// </summary>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(time_and_date_widget_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context));

            // Vytvoří a spustí časovač pro aktualizaci widgetu každou 1 sekundu
            timer = new System.Timers.Timer(1000); // 1000 milisekund = 1 sekunda
            timer.Elapsed += (sender, e) => UpdateWidgetText(appWidgetManager, context);
            timer.AutoReset = true;
            timer.Start();
        }

        /// <summary>
        /// Metoda BuildRemoteViews vytvoří (aktualizuje) vzhled a fukce widgetu.
        /// </summary>
        private RemoteViews BuildRemoteViews(Context context) {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.time_and_date_widget_layout);

            SetTextViewText(widgetView);

            return widgetView;
        }

        /// <summary>
        /// Metoda UpdateWidgetText aktualizuje text widgetu.
        /// </summary>
        private void UpdateWidgetText(AppWidgetManager appWidgetManager, Context context) {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(time_and_date_widget_class)).Name);
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.time_and_date_widget_layout);
            SetTextViewText(widgetView);
            appWidgetManager.UpdateAppWidget(me, widgetView);
        }

        /// <summary>
        /// Metoda SetTextViewText nastaví text widgetu na aktuální datum a čas.
        /// </summary>
        private void SetTextViewText(RemoteViews widgetView) {
            widgetView.SetTextViewText(Resource.Id.time_and_date_widget_time_and_date, DateTime.Now.ToString("H:mm:ss\nd.M.yyy"));
        }
    }
}
