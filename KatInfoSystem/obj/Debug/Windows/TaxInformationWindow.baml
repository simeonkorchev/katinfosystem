   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Presentation.WindowsPresentation.Windows  5      A%clr-namespace:Presentation.ConvertersPresentation.Converters  5      /    )Presentation.Windows.TaxInformationWindow   5      -Custom"clr-namespace:Presentation.Windows  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
converters%clr-namespace:Presentation.Converters     5        � Title$  FinesInformationWindow��5      $	��450��6/   $	��800��6<    � 	Resources 5      3  -Presentation.Converters.ExistenceToVisibility   ЕxistenceToVisibility��%   &	          5   
   6+   5	      .��5
      �   	MainFrame#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��2��6!   $$��Справка за данък��65    	 Title#��[ 6M   �� 5   
   $��0��6   $��ВИН��6    $��1��6.   �� 5   
   $��1��6   $��1��6   ��6/   �� *Vin+6F   �� 5   
   $��3��6i   $��2��6v   y�6   �� *	TaxesText+ �� 	Converter# [  ��6�   �� *	TaxesText+6�   �� 5   
   $��2��6l   $��2��6y     ErrorMessage#��[ 6�   y�6   �� *ErrorMessage+# [  ��6�   �� *ErrorMessage+6�   �� 5   
   $��4��6d   $��1��6q   $��Принтирай��6�     	BigButton#��[ 6�   y�6   �� *	TaxesText+# [  ��6�   �� *PrintCommand+�� 5   
   $��3��6   $��2��6   $��
Плати��6.   #��[ 6>   y�6a   �� *	TaxesText+# [  ��6�   �� *
PayCommand+�� 5    
   $��1��6   $��2��6   $��Провери��6.   #��[ 6@   ��6c   �� *CheckTaxesCommand+�� 5!   
   $��4��6   $��2��6   $��Cancel��6.   #��[ 6`   ��6?   �� *CloseCommand+6`   5"      5#      