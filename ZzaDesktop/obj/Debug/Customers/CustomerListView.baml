   M S B A M L   `   `   `  ����E  AZzaDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ZzaDesktop.CustomersZzaDesktop.Customers  5      +    %ZzaDesktop.Customers.CustomerListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ZzaDesktop.Customers     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6S   .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ LoadCustomers��6;      TargetObject 6"   �� 6;   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5   
   �� $��Add Customer��6   $
��Left=�5      ��5      �� *AddCustomerCommand+5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��1��6N   .+�5      �� $��Search:��6   �� 5!      $	��150��6\   ��6   �� *SearchInput+ �� UpdateSourceTrigger$ PropertyChanged=�6\   �� 5"      $��X��6   ��6%   �� *ClearSearchCommand+5#      5$      &   System.Windows.Controls.DataGrid  5%   
   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  $��1��5(      ��5%      �� *	Customers+   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6B   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *
FullName+6B   4
  .System.Windows.Controls.DataGridTemplateColumn
  5+      $
 Auto 6)    
  CellTemplate 5,      �� 5-      .R�5.      �� $��Place Order��6%   $��5q�51   %   ��5/   %   �� *DataContext.PlaceOrderCommand+ �� RelativeSource ��  �� AncestorType"  ��50   %   �� 51   %   53      55      
  56      $
 Auto 6)    57      �� 58      .R�59      �� $��Edit Customer��6%   $��5q�5<   %   ��5:   %   �� *!DataContext.EditCustomerCommand+ �� "  ��5;   %   �� 5<   %   5>      5@      5C      5D      5E      