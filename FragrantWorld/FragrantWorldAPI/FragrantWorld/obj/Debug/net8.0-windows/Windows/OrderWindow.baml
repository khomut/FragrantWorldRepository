   M S B A M L   `   `   `  ����H  DFragrantWorld, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FragrantWorld.WindowsFragrantWorld.Windows  5   	   '    !FragrantWorld.Windows.OrderWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:FragrantWorld.Windows     5   	   -   5           AppWindowStyle#��[  5   	     � Title$  Ваш заказ��5	   	   $	��450��6   $	��800��6(   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5      �� 
�������.+�5   
   �� $+��%Информация о заказе:��6   $
��Bold"�60   �� 5   
   -   5        $��OrderIdTextBlock��5      ��6,   ��  �� StringFormat$" Номер заказа: {0}�� �� Path$ OrderId��� 5   
   -   5        $��OrderCostTextBlock��5      �� 5   
   -   5        $��OrderDateTextBlock��5      ��6.   �� $  Дата заказа: {0}�� �� ConverterCulture$ ru-ru��$ 	OrderDate��� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��Пункт выдачи:��6   �� 5      -   5        $��PickupPointsComboBox��5       �� DisplayMemberPath$ PickupPointAddress��63   5      5      �� 5   
   -   5        $��ReceiptCodeTextBlock��5      $
��Bold"�5      $��14(�6   ��5   0   �� $$ Код получения: {0}��$ ReceiptCode�5      �� 5      -   5        $��SaveTicketButton��5      $>��8Выбрать файл и сохранить талон��6-   6V   5      �� 5   
   -   5        $��ProductsScrollViewer��5      $
��Auto=�63   $��Hidden=�6V   $��Stretch=�5       $��1��6'   .��5!      �� -	   5        $��ProductsListBox��5!      ��5"      �� 5#       �� 
TargetType" ��6   .�5$      ��  �� Property � ��	 �� Value$	 Stretch=�6G   5%      ��5'      �� 5(      .R�5)      �� 
���   �$��1q�65   $��5q�6I   
 �� Padding$
 5q�6T   ._�5*      �� $	��740��6)   .+�5+   "   �� $
��Bold"�6I   ��6,   �� *ProductName+6I   �� 5,   "   ��6,   �� $ Артикул: {0}��$ ProductArticle��� 5-   "   ��6,   �� *ProductDescription+�� 5.   "   ��6,   �� $% Производитель: {0}��$ ProductManufacturer��� 5/   "   ��6,   �� $ Цена: {0}��$ ProductCost��� 50   "   ��6,   �� $ Скидка: {0}%��$ ProductDiscountAmount��� 51   "   ��6,   �� $ Категория: {0}��$ ProductCategory��� 52   "   ��6,   �� $ Статус: {0}��$ ProductStatus��� 53   "   ��6,   �� $ Количество: {0}��$ Amount��� 54   "   $��DeleteButton��6)   -
   5        $��Удалить��54   =   $��70��6O   $��Right=�6Z   6v   55      56      57      59      5:      5;      5<      