   M S B A M L   `   `   `  ����E  AZzaDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ZzaDesktop.CustomersZzaDesktop.Customers  5      C ?Zza.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:Zza.Data;assembly=Zza.DataZza.Data 5      =#clr-namespace:ZzaDesktop.ConvertorsZzaDesktop.Convertors  5      .    (ZzaDesktop.Customers.AddEditCustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ZzaDesktop.Customers     5      9Data(clr-namespace:Zza.Data;assembly=Zza.Data     5      4conv#clr-namespace:ZzaDesktop.Convertors     5        � 	Resources  5      A   ;ZzaDesktop.Convertors.NegatableBooleanToVisibilityConvertor   VisConvertor  NegVisConvertor   Negate �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path��%  &	        &	      '�� -       5   
   65     5   
    . 6M   �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� #	 Z $5
 /AdornedElement.(Validation.Errors)/ErrorContent�5      5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   .+�5'   
   � -   5         �Name$ grid1��5'      $	��Top=�6   $��	55,62,0,0q�66   $
��Left=�5(       � DataContext 5)      �� *
Customer+ 5+      �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6     � ColumnDefinitions 51      �� 52      $
��Auto �6#   �� 53      $
��Auto �6#   .+�55      �� $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��First Name:��6r   �� 56      -   5         ��Name$ firstNameTextBox��56      $	��120��60   $��Center=�6<   $��0��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6W   �� *	FirstName+ �� ValidatesOnDataErrors . 6�   �� 57      $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Last Name:��6r   �� 58      -   5        $ lastNameTextBox��58      $	��120��6/   $��Center=�6;   $��1��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6V   �� *
LastName+ . 6�   �� 59      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Email:��6r   �� 5:      -   5        $ emailTextBox��5:      $	��120��6,   $��Center=�68   $��2��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6S   �� *Email+ . 6�   �� 5;      $��Center=�6   $��3��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Phone:��6r   �� 5<      -   5        $ phoneTextBox��5<      $	��120��6,   $��Center=�68   $��3��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6S   �� *Phone+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   5=      � 5?   
   $��1��6   .+�5@      �� $
��Save��6   $
��Left=�6D   $��75��6_   $��25,5,0,0q�6j   ��6$   �� *SaveCommand+y�5A      �� *
EditMode+ �� 	Converter# [  �� 5B      $	��Add��6   $
��Left=�6C   $��75��6^   $��25,5,0,0q�6i   ��6#   �� *SaveCommand+y�5C      �� *
EditMode+# [ �� 5E      $��Cancel��6   $
��Left=�6H   $��75��6c   $��	150,5,0,0q�6n   ��6&   �� *CancelCommand+6n   5F      5H      5I      