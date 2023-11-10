using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Bumptech.Glide.Request.Target;
using Bumptech.Glide.Util;
using static Android.Widget.RemoteViews;

namespace MauiWidgets.Platforms.Android {

    [BroadcastReceiver(Label = "light bulb switch", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/light_bulb_switch_widget_provider")]
    [Service(Exported = true)]
    internal class light_bulb_switch_widget_class : AppWidgetProvider {
        /// <summary>
        /// Něco jako konstruktor, povětšinou 2 první řádky zůstávají stejné.
        /// </summary>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(light_bulb_switch_widget_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context));
        }

        /// <summary>
        /// Metoda BuildRemoteViews vytvoří (aktualizuje) vzhled a fukce widgetu.
        /// </summary>
        private RemoteViews BuildRemoteViews(Context context) {
            RemoteViews widgetView = new RemoteViews(context.PackageName, Resource.Layout.light_bulb_switch_widget_layout);

            // Vytvoření intentu pro switch
            Intent intent_switch = new Intent(context, typeof(light_bulb_switch_widget_class));

            // Nastavení akce pro switch
            intent_switch.SetAction("switch");

            // Vytvoření PendingIntent pro switch
            PendingIntent pendingIntent_switch = PendingIntent.GetBroadcast(context, 0, intent_switch, PendingIntentFlags.Immutable);

            // Nastavení onClick PendingIntent pro switch
            widgetView.SetOnClickPendingIntent(Resource.Id.light_bulb_switch_widget_switch, pendingIntent_switch);

            return widgetView;
        }

        /// <summary>
        /// Metoda OnReceive reaguje na kliky na widget.
        /// </summary>
        public override void OnReceive(Context context, Intent intent) {
            RemoteViews widgetView = BuildRemoteViews(context);
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(light_bulb_switch_widget_class)).Name);
            if (intent.Action == "switch") {

                //TODO: Dostat atribut Text z "light_bulb_switch_widget_switch"
               


            }

            AppWidgetManager appWidgetManager = AppWidgetManager.GetInstance(context);

            // Aktualizace widgetu
            appWidgetManager.UpdateAppWidget(me, widgetView);

            // Volání metody z nadřazené třídy
            base.OnReceive(context, intent);
        }
    }
}
