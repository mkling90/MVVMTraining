   M S B A M L   `   `   `  ����G  CMVVMTraining, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MVVMTraining.CustomersMVVMTraining.Customers  5      +clr-namespace:MVVMTrainingMVVMTraining  5      C ?Zza.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Zza.Data;assembly=Zza.DataZza.Data 5      -    'MVVMTraining.Customers.CustomerListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5cust$clr-namespace:MVVMTraining.Customers     5      ,localclr-namespace:MVVMTraining     5      9data(clr-namespace:Zza.Data;assembly=Zza.Data     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5
      #   MVVMTraining.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5       �� DataType  Zza.Data.Customer��%�   (��       5      *, +)�� 6
   "  6   .R�5      �� .+�5      �� ��6   �� *	FirstName+�� 5      ��6   �� *
LastName+�� 5      ��6   �� *Phone+5      5      5       J� InputBindings 5       �� 5!   
   
 �� Key$ D��6    �� 	Modifiers$
 Ctrlf�5"       �� Command 5#      �� *DeleteCommand+.  (System.Windows.Interactivity.Interaction   Triggers 5&      /  )System.Windows.Interactivity.EventTrigger  5'   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5(      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  
   
MethodName$
 LoadCustomers��6;      TargetObject 6"   �� 6;   5)      .��5,      �  � RowDefinitions 5-   
   �� 5.      $
��Auto �6   �� 5/      $��2* �6   �� 50      $��* �6    � ColumnDefinitions 52   
   �� 53      $��2* �6   �� 54      $��* �6   .+�57   
   �� $��Delete��6   $
��Left=�59      $	��Top=�5:      $��75��5;      ��58      �� *DeleteCommand+5;      �� 5<   
   -   5        $��Change Customer��5<      $
��Left=�5=      $	��Top=�5>      $��80,0,0,0q�5?      $	��100��5@      5A      &   System.Windows.Controls.DataGrid  5C   
   -   5          Name$ customerDataGrid��5C         AutoGenerateColumns .     EnableRowVirtualization . $��1��5G         RowDetailsVisibilityMode$ VisibleWhenSelected=�5H      ��5E      �� *	Customers+ �� SelectedItem 5F      �� *SelectedCustomer+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      -   5        firstNameColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ 
First Name��5L   %    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader
 5M   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5K   %   �� *	FirstName+5M   %     5N      -   5        lastNameColumn��$ 	Last Name��5P   %   $ SizeToHeader
 5Q   %    5O   %   �� *
LastName+5Q   %     5R      -   5        phoneColumn��$ Phone��5T   %   $ SizeToHeader
 5U   %    5S   %   �� *Phone+5U   %   5X      �� 5Y   
   $��1��6   $��1��6   ��5Z      �� *	Customers+5\      5]      