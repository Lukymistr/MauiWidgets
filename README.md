# MauiWidgets
 Maui app with some widgets
### soubory
- [MauiWidgets.csproj](MauiWidgets.csproj)
   - ApplicationTitle -> změna názvu
   - MauiSplashScreen -> změná obrázku při načítání
   - MauiIcon -> icona na ploše (zatím nefunguje)
- [Platforms](Platforms/)
   - [Android](Platforms/Android/)
      - [Resources](Platforms/Android/Resources/)
         - [drawable](Platforms/Android/Resources/drawable/)
            - [time_and_date_widget_image.png](Platforms/Android/Resources/drawable/time_and_date_widget_image.png)
               - náhled "time_and_date" widgetu při přidávání na plochu
            - [color_press_game_widget_image.png](Platforms/Android/Resources/drawable/color_press_game_widget_image.png)
               - náhled "color_press_game" widgetu při přidávání na plochu
         - [layout](Platforms/Android/Resources/layout)
            - [time_and_date_widget_layout.xml](Platforms/Android/Resources/layout/time_and_date_widget_layout.xml)
               - struktura "time_and_date" widgetu
            - [color_press_game_widget_layout.xml](Platforms/Android/Resources/layout/color_press_game_widget_layout.xml)
               - struktura "color_press_game" widgetu
         - [values](Platforms/Android/Resources/values)
            - [colors.xml](Platforms/Android/Resources/values/colors.xml)
               - kódy užitcýh barev (informativní)
         - [xml](Platforms/Android/Resources/xml)
            - [time_and_date_widget_provider.xml](Platforms/Android/Resources/xml/time_and_date_widget_provider.xml)
               - struktura celého "time_and_date" widgetu (př. minimální velikost)
            - [color_press_game_widget_provider.xml](Platforms/Android/Resources/xml/color_press_game_widget_provider.xml)
               - struktura celého "color_press_game" widgetu (př. minimální velikost)
      - [time_and_date_widget_class](Platforms/Android/time_and_date_widget_class.cs)
         - je zde celé gró "time_and_date" widgetu
      - [color_press_game_widget_class](Platforms/Android/color_press_game_widget_class.cs)
         - je zde celé gró "color_press_game" widgetu
- [Resources](Resources/)
   - icony, fonty, obrázky, styly a aplikace
   - [AppIcon](Resources/AppIcon)
      - jsou zde uložny obrázky pro načítání a iconu apliakce
- [App.xaml](App.xaml)
   - načítaní barev a stylů z "Resources"
- [App.xaml.cs](App.xaml.cs)
   - výchozí bod při spuštění aplikace
   - spustí "App.xaml"
   - vyvoří instanci "AppShell.xaml.cs"
- [AppShell.xaml](AppShell.xaml)
   - nastavení aplikace -> načte grafiku z "MainPage.xaml" + přidá (př. nadpis)
- [AppShell.xaml.cs](AppShell.xaml.cs)
   - spustí "AppShell.xaml"
- [MainPage.xaml](MainPage.xaml)
   - výchozí grafický kontent aplikace
- [MainPage.xaml.cs](MainPage.xaml.cs)
   - funkcionalita pro "MainPage.xaml"

### Aplikace
- Defaultní Maui aplikace, klikání na tlačítko

### Android widget
- #### "time_and_date"
  - ##### grafika
    - Barva textu je "#ffffff" (bílá)
    - Barva pozadí průhledná

  - ##### funkcionalita
    - Čas je řešen přes vlákna, každou sekudnu se přepíše stávající čas na nový, který se vezme a zformátuje z [DateTime][DATE]
      - tato funkcionatlita se schována v souboru [time_and_date_class.cs](Platforms/Android/time_and_date_class.cs) v metodě [UpdateWidgetText](Platforms/Android/time_and_date_class.cs#L57)

- #### "color_press_game"
  - ##### grafika
    - Barva textu je "#000000" (černá)
    - počet bloků je 5
    - Barvy bloků
      - "#ff99cc00" (zelená)
      - "#ff33b5e5" (modrá)
      - "#ffff4444" (červená)
      - "#ffaa66cc" (fialová)
      - "#ffffff" (bílá)

  - ##### funkcionalita
    - když se klikne na na blok, tak se jeho text změní na "clicked" a ostatním blokům se text dá na defaultní hodnotu


   [DATE]: <https://learn.microsoft.com/cs-cz/dotnet/api/system.datetime?view=net-7.0>
