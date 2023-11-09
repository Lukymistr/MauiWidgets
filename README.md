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
            - [color_press_game_widget_image.png](Platforms/Android/Resources/drawable/color_press_game_widget_image.png)
               - náhled "color_press_game" widgetu při přidávání na plochu
            - [light_bulb_buttons_and_switch_widget_image.png](Platforms/Android/Resources/drawable/light_bulb_buttons_and_switch_widget_image.png)
               - náhled "light_bulb_buttons" a "light_bulb_switch" widgetu při přidávání na plochu
            - [light_bulb_buttons_and_switch_widget_image_off.png](Platforms/Android/Resources/drawable/light_bulb_buttons_and_switch_widget_image_off.png)
               - foto pro zhasnutou žárovku
            - [light_bulb_buttons_and_switch_widget_image_on.png](Platforms/Android/Resources/drawable/light_bulb_buttons_and_switch_widget_image_on.png)
               - foto pro rozsvícenou žárovku
            - [time_and_date_widget_image.png](Platforms/Android/Resources/drawable/time_and_date_widget_image.png)
               - náhled "time_and_date" widgetu při přidávání na plochu
         - [layout](Platforms/Android/Resources/layout)
            - [color_press_game_widget_layout.xml](Platforms/Android/Resources/layout/color_press_game_widget_layout.xml)
               - struktura "color_press_game" widgetu
            - [light_bulb_buttons_widget_layout.xml](Platforms/Android/Resources/layout/light_bulb_buttons_widget_layout.xml)
               - struktura "light_bulb_buttons" widgetu
            - [light_bulb_switch_widget_layout.xml](Platforms/Android/Resources/layout/light_bulb_switch_widget_layout.xml)
               - struktura "light_bulb_switch" widgetu
            - [time_and_date_widget_layout.xml](Platforms/Android/Resources/layout/time_and_date_widget_layout.xml)
               - struktura "time_and_date" widgetu
         - [values](Platforms/Android/Resources/values)
            - [colors.xml](Platforms/Android/Resources/values/colors.xml)
               - kódy užitcýh barev (informativní)
         - [xml](Platforms/Android/Resources/xml)
            - [color_press_game_widget_provider.xml](Platforms/Android/Resources/xml/color_press_game_widget_provider.xml)
               - struktura celého "color_press_game" widgetu (př. minimální velikost)
            - [light_bulb_buttons_widget_provider.xml](Platforms/Android/Resources/xml/light_bulb_buttons_widget_provider.xml)
               - struktura celého "light_bulb_buttons" widgetu (př. minimální velikost)
            - [light_bulb_switch_widget_provider.xml](Platforms/Android/Resources/xml/light_bulb_switch_widget_provider.xml)
               - struktura celého "light_bulb_switch" widgetu (př. minimální velikost)
            - [time_and_date_widget_provider.xml](Platforms/Android/Resources/xml/time_and_date_widget_provider.xml)
               - struktura celého "time_and_date" widgetu (př. minimální velikost)
      - [color_press_game_widget_class](Platforms/Android/color_press_game_widget_class.cs)
         - je zde celé gró "color_press_game" widgetu
      - [light_bulb_button_widget_class.cs](Platforms/Android/light_bulb_button_widget_class.cs)
         - je zde celé gró "light_bulb_button" widgetu
      - [light_bulb_switch_widget_class.cs](Platforms/Android/light_bulb_switch_widget_class.cs)
         - je zde celé gró "light_bulb_switch" widgetu
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
    - když se klikne na blok, tak se jeho text změní na "clicked" a ostatním blokům se text dá na defaultní hodnotu
      
- #### "light_bulb_buttons"
  - ##### grafika
    - Barva textu je "#ffffff" (bílá)
    - počet bloků je 3
    - Barvy bloků
      - "#5a595b" (šedá)
      - "#5a595b" (šedá)
      - "#aaaaaa" (světle šedá)

  - ##### funkcionalita
    - když se klikne na tlačítko on, tak se změní adresa obrázku na rozsvícenou žárovku a když se klikne na tlačítko off, tak se zpět změní na zhasnutou (nekonečně se opakujíc)

- #### "light_bulb_switch"
  - ##### grafika
    - Barva textu je "#ffffff" (bílá)
    - počet bloků je 3
    - Barvy bloků
      - "#5a595b" (šedá)
      - "#5a595b" (šedá)
      - "#aaaaaa" (světle šedá)

  - ##### funkcionalita
    - když se klikne na switch, tak se změní adresa obrázku na rozsvícenou žárovku a když znovu tak zpět na zhasnutou (nekonečně se opakujíc)


   [DATE]: <https://learn.microsoft.com/cs-cz/dotnet/api/system.datetime?view=net-7.0>
