   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Presentation.WindowsPresentation.Windows  5      A%clr-namespace:Presentation.ConvertersPresentation.Converters  5      2    ,Presentation.Windows.TransferOwnershipWindow   5      -Custom"clr-namespace:Presentation.Windows  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
converters%clr-namespace:Presentation.Converters     5        � Title$  FinesInformationWindow��5      $	��450��6/   $	��800��6<    � 	Resources 5      3  -Presentation.Converters.ExistenceToVisibility   ExistenceToVisibility��%   &	          5   
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
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��2��6!   $8��2Прехвърляне на собственост��65    	 Title#��[ 6W   �� 5   
   $��1��6   $��0��6!   $2��,ЕГН на текущ собственик:��61   6S   �� 5   
   $��2��6   $��0��6   ��6/   �� *CurrentOwnerEgn+6R   �� 5   
   $��1��6   $��1��6!   $2��,ЕГН на текущ собственик:��61   6S   �� 5   
   $��2��6   $��1��6   ��6/   �� *NewOwnerEgn+6N   �� 5   
   $��3��6   $��0��6!   $��Вин на МПС:��61   6F   �� 5    
   $��4��6   $��0��6   ��6/   �� *Vin+6F   �� 5!   
   $��4��6   $��1��6   $��Прехвърли��6[   ��6.   �� *TransferOwnershipCommand+6q   �� 5"   
   $��5��6   $��2��6   $��Cancel��6.     	BigButton#��[ 6`   ��6?   �� *CloseCommand+6`   �� 5#   
   $��6��6   $��2��6!     ErrorMessage#��[ 6�   ��65   �� *ErrorMessage+y�6S   �� *	FinesText+ �� 	Converter# [  6�   5$      5%      