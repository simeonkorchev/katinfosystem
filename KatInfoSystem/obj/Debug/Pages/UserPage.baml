   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Presentation.PagesPresentation.Pages  5      A%clr-namespace:Presentation.ConvertersPresentation.Converters  5      !    Presentation.Pages.UserPage   5      +Custom clr-namespace:Presentation.Pages  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <
converters%clr-namespace:Presentation.Converters     5        � 	Resources  5      5   /Presentation.Converters.UserToGreetingConverter   UserToGreetingConverter��%   &	          5   
   6-   5      .��5	      �   	MainFrame#��[ 6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��2��6!    	 Title#��[ 6   ��65   �� *user+ �� 	Converter# [  6   �� 5   
   $��2��6   $��1��6"   .+�5      �� $4��.Регистрация на автомобил��6   ��68   �� *&$OpenVehicleRegistrationWindowCommand+�� 5      $&�� Добавяне на глоба��6   ��61   �� *OpenAddFinesWindowCommand+�� 5      $&�� Добавяне на данък��6   ��61   �� *OpenAddTaxWindowCommand+�� 5      $6��0Справка и плащане на глоба��6   ��6:   �� *#!OpenFinesInformationWindowCommand+�� 5      $6��0Справка и плащане на данък��6   ��6:   �� *!OpenTaxInformationWindowCommand+�� 5      $8��2Прехвърляне на собственост��6   ��6:   �� *$"OpenTransferOwnershipWindowCommand+�� 5      $��
Изход��6   ��6%   �� *ExitCommand+5      5      5       