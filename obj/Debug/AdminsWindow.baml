   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   R NProjectManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjectManagementSystemProjectManagementSystem 5   	   Q-clr-namespace:ProjectManagementSystem.ScriptsProjectManagementSystem.Scripts 5   	   *   $ProjectManagementSystem.AdminsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ProjectManagementSystem     5   	   Ascripts-clr-namespace:ProjectManagementSystem.Scripts     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	       � Title$ AdminsWindow��5
   	   $	��450��6   $	��800��6+    � 	Resources 5         enumData S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName4 .ProjectManagementSystem.Scripts.RegistredUsers  
ComboItems��%�   &	        &	 n     S� 5   
   $ 	GetValues��6.   "  6E    5      M� 5      $ scripts:TaskState��6   5        5   
   6!   5      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��Right=�6F   $��30��6b   $��5q�6q   .+�5      �� -   5         ��Name$ UserNameTextBox��5      $��Center=�61   $
��10 0q�6L   6\   �� 5      -   5        $	��Top=�5      $��50��6-   $��25��6;   .��6b   " Выйти из аккаунта5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 TaskGrid��5      $��	5 40 5 50q�6%   $��12(�68   $
��Bold"�6F   
   AutoGenerateColumns
 .     CanUserAddRows .   5      ��%    5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID проекта��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ 	ProjectID�6H     5$      $ Название��6C    6%   �� $
 Name�6C     5%      $ Описание��6J    6%   �� $ Discription�6J   4  .System.Windows.Controls.DataGridComboBoxColumn  5'      -   5        EmployeeComboBox��$  Ответственный��5'   �      ItemsSource 6C   �� $ 	UserNames� �� Source# [    SelectedItemBinding 6�   �� *
Employee+6�     5(      $ Состояние��6�    6)   �� # [   �� UpdateSourceTrigger$ PropertyChanged=� 6�   �� *State+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ Delete��6)      CellTemplate 5*      �� 5+      .R�5,      �� $��Delete��6%   $��Delete��66   5-      5/      51      �� 52   
   $��Bottom=�6   $��Right=�60   $ 
Horizontal=�6L   $��10q�6e   .+�53      �� -   5        $
��10 0q�53      $��30��6#   $��Bottom=�62   .��6g   Добавить задачу6x   54      �� 55   
   $��Bottom=�6   $
��Left=�60   $ 
Horizontal=�6K   $��10q�6d   .+�56      �� -   5        $
��10 0q�56      $��30��6#   $��Bottom=�62   .��6l   53Зарегистрировать работника6�   57      �� 58   
   $��Bottom=�6   $��Center=�60   $ 
Horizontal=�6M   $��10q�6f   .+�59      �� -   5         ��Name$ EmployeeToDelete��59      $	��100��61    �� 
IsEditable .  �� 
IsReadOnly .  �� Text$! Выберите логин��6�   ��6@   �� $ 	UserNames�# [ 6�   �� 5:      -	   5        $
��10 0q�5:      $��30��6#   $��Bottom=�62   .��6e   20Удалить аккаунт работника6�   5;      5=      5>      