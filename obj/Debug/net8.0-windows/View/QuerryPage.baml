   M S B A M L   `   `   `  ����D  @ClientApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClientApi.ViewClientApi.View  5          ClientApi.View.QuerryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ClientApi.View     5        N� 
Background  �#333 N� Title$ 
QuerryPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$
 Deyt��5   N   $��0��6   $��20(�6\   $��10 20q�6j      SelectedDate 6"   �� *DateOf+ �� Mode$ TwoWay=�6j   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ sort1��5      $��0��6$   $��Цена��6R   $��20(�6a   $	�� 10q�6o   ��64   �� *	Sortfirst+6o   �� 5      -   5        $ sort2��5      $��1��6$   $��Обем выручки��6S   $��20(�6j   $	�� 10q�6x   ��64   �� *
Sortsecond+6x   5      �� 5   
   -   5         ��Name$ PriceListView��5      $��2��6*   $��10q�67   $��20(�6C   ���#333
�������$��2��5      ��5   Q   �� *Counts+��5      �� 5      .R�5       �� 	 �� Orientation$	 Vertical=�6!   .+�5!      �� ��6$   �� 
 �� StringFormat$!
 Дата продажи {0}�� �� Path$ 
DateOfSale��� 5"      ��6$   �� $
 CodeGood {0}��$ CodeGood��� 5#      ��6$   �� $'
 !Колво Проданных {0}��$ CountOfSold��� 5$      ��6$   �� $
 PriceGood {0}��$ 	PriceGood�5&      5'      5)      5*      5+      