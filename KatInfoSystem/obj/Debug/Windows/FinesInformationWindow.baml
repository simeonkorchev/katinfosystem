   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Presentation.WindowsPresentation.Windows  5      A%clr-namespace:Presentation.ConvertersPresentation.Converters  5      1    +Presentation.Windows.FinesInformationWindow   5      -Custom"clr-namespace:Presentation.Windows  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
converters%clr-namespace:Presentation.Converters     5        � Title$  FinesInformationWindow��5      $	��600��6/   $	��850��6<    � 	Resources 5      3  -Presentation.Converters.ExistenceToVisibility   ExistenceToVisibility��%   &	          5   
   6+   5	      .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��2��6!   $$��Справка за глоби��65    	 Title#��[ 6M   �� 5   
   $��0��6   $��1��6!   $��ЕГН:��6.   6?   �� 5   
   $��1��6   $��1��6   ��6/   �� *Egn+6F   �� 5   
   $��3��6   $��2��6   ��63   �� *	FinesText+y�6N   �� *	FinesText+ �� 	Converter# [  6�   �� 5   
   $��2��6     ErrorMessage#��[ 6?   ��6!   �� *ErrorMessage+6g   �� 5   
   $��3��6   $��2��6   $��Принтирай��6.     	BigButton#��[ 6�   y�6B   �� *	FinesText+# [  ��6�   �� *PrintCommand+6�   �� 5   
   $��4��6   $��1��6   $��
Плати��6.   #��[ 6�   y�6>   �� *	FinesText+# [  ��6�   �� *
PayCommand+6�   �� 5    
   -   5        $��FinesLV��5        $��4��6   $��0��6/   ��6?   �� *	FinesList+y�6a   �� *	FinesText+# [  6�   �� 5!   
   $��4��6   $��2��6   $��Cancel��6.   #��[ 6`   ��6?   �� *CloseCommand+6`   �� 5"   
   $��1��6   $��2��6   $��Провери��6.   #��[ 6f   ��6@   �� *CheckFinesCommand+6f   5#      5$      