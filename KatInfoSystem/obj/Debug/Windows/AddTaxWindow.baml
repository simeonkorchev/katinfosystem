   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Presentation.WindowsPresentation.Windows  5      A%clr-namespace:Presentation.ConvertersPresentation.Converters  5      '    !Presentation.Windows.AddTaxWindow   5      -Custom"clr-namespace:Presentation.Windows  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
converters%clr-namespace:Presentation.Converters     5        � Title$(  "Въвеждане на данък��5      $	��450��6+   $	��800��68   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   6-   �� 5
      $
��Auto �6   6-   �� 5      $
��Auto �6   6-   �� 5      $
��Auto �6   6-   �� 5      $
��Auto �6   6-   �� 5      $
��Auto �6   6-    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��2��6!   $(��"Въвеждане на данък��65    	  Title#��[  6O   �� 5   
   $��1��6   $��0��6   .��6-   	ВИН:63   �� 5   
   $��1��6   $��1��6   ��6/   �� *Vin+6F   �� 5   
   $��2��6   $��0��6   .��6-   
Сума63   �� 5   
   $��2��6   $��1��6   ��6/   �� *Amount+6I   �� 5   
   $��4��6   $��2��6"     ErrorMessage#��[ 6U   ��67   �� *ErrorMessage+6U   �� 5   
   $��5��6   $��0��6   $��Въведи��6.     	BigButton#��[ 6^   ��6?   �� *
AddCommand+6^   �� 5   
   $��5��6   $��1��6   $��Cancel��6.   #��[ 6`   ��6?   �� *CloseCommand+6`   5      5      