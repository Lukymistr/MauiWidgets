using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;

namespace MauiWidgets.Platforms.Android {

    [BroadcastReceiver(Label = "light bulb buttons", Exported = true)]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/light_bulb_buttons_widget_provider")]
    [Service(Exported = true)]
    internal class light_bulb_buttons_widget_class : AppWidgetProvider {
        /// <summary>
        /// Něco jako konstruktor, povětšinou 2 první řádky zůstávají stejné.
        /// </summary>
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(light_bulb_buttons_widget_class)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context));
        }

        /// <summary>
        /// Metoda BuildRemoteViews vytvoří (aktualizuje) vzhled a fukce widgetu.
        /// </summary>
        private RemoteViews BuildRemoteViews(Context context) {
            RemoteViews widgetView = new RemoteViews(context.PackageName, Resource.Layout.light_bulb_buttons_widget_layout);

            // Vytvoření intentů pro jednotlivá tlačítka
            Intent intent_on = new Intent(context, typeof(light_bulb_buttons_widget_class));
            Intent intent_off = new Intent(context, typeof(light_bulb_buttons_widget_class));

            // Nastavení akcí pro jednotlivá tlačítka
            intent_on.SetAction("set_on");
            intent_off.SetAction("set_off");

            // Vytvoření PendingIntent pro jednotlivá tlačítka
            PendingIntent pendingIntent_on = PendingIntent.GetBroadcast(context, 0, intent_on, PendingIntentFlags.Immutable);
            PendingIntent pendingIntent_off = PendingIntent.GetBroadcast(context, 0, intent_off, PendingIntentFlags.Immutable);

            // Nastavení onClick PendingIntent pro jednotlivá tlačítka
            widgetView.SetOnClickPendingIntent(Resource.Id.light_bulb_buttons_widget_on, pendingIntent_on);
            widgetView.SetOnClickPendingIntent(Resource.Id.light_bulb_buttons_widget_off, pendingIntent_off);

            return widgetView;
        }

        /// <summary>
        /// Metoda OnReceive reaguje na kliky na widget.
        /// </summary>
        public override void OnReceive(Context context, Intent intent) {
            RemoteViews widgetView = BuildRemoteViews(context);
            ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(light_bulb_buttons_widget_class)).Name);

            switch (intent.Action) {
                case "set_on":
                    // Akce pro kliknutí na tlačítko on
                    widgetView.SetImageViewResource(Resource.Id.light_bulb_buttons_widget_light_bulb, Resource.Drawable.light_bulb_buttons_and_switch_widget_image_on);
                    break;
                case "set_off":
                    // Akce pro kliknutí na tlačítko off
                    widgetView.SetImageViewResource(Resource.Id.light_bulb_buttons_widget_light_bulb, Resource.Drawable.light_bulb_buttons_and_switch_widget_image_off);
                    break;
                default:
                    // Element nemá nastavenou onClick funkci
                    break;
            }

            AppWidgetManager appWidgetManager = AppWidgetManager.GetInstance(context);

            // Aktualizace widgetu
            appWidgetManager.UpdateAppWidget(me, widgetView);

            // Volání metody z nadřazené třídy
            base.OnReceive(context, intent);
        }
    }
}
