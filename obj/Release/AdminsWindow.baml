   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  R NProjectManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjectManagementSystemProjectManagementSystem Q-clr-namespace:ProjectManagementSystem.ScriptsProjectManagementSystem.Scripts *   $ProjectManagementSystem.AdminsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:ProjectManagementSystem     Ascripts-clr-namespace:ProjectManagementSystem.Scripts     -     � WindowStartupLocation$  CenterScreen=� � Title$ AdminsWindow��$	��450��$	��800�� � 	Resources    enumData S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName4 .ProjectManagementSystem.Scripts.RegistredUsers  
ComboItems��%T   &	        &	 ;     S� $ 	GetValues��"   M� $ scripts:TaskState��  .��� .+���  �� Orientation$ 
Horizontal=�$	��Top=�$��Right=�$��30��$��5q�.+��� -    ��Name$ UserNameTextBox��$��Center=�$
��10 0q��� -   $	��Top=�$��50��$��25��.��" Выйти из аккаунта&   System.Windows.Controls.DataGrid  -   	  Name$	 TaskGrid��$��	5 40 5 50q�$��12(�$
��Bold"�
   AutoGenerateColumns
 .     CanUserAddRows .   ��%       Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID проекта��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ 	ProjectID�  $ Название�� �� $
 Name�  $ Описание�� �� $ Discription�4  .System.Windows.Controls.DataGridComboBoxColumn  -   EmployeeComboBox��$  Ответственный��   ItemsSource �� $ 	UserNames� �� Source# [    SelectedItemBinding �� *
Employee+  $ Состояние�� �� # [   �� UpdateSourceTrigger$ PropertyChanged=� �� *State+4  .System.Windows.Controls.DataGridTemplateColumn  $ Delete��   CellTemplate �� .R��� $��Delete��$��Delete���� $��Bottom=�$��Right=�$ 
Horizontal=�$��10q�.+��� -   $
��10 0q�$��30��$��Bottom=�.��Добавить задачу�� $��Bottom=�$
��Left=�$ 
Horizontal=�$��10q�.+��� -   $
��10 0q�$��30��$��Bottom=�.��53Зарегистрировать работника�� $��Bottom=�$��Center=�$ 
Horizontal=�$��10q�.+��� -    ��Name$ EmployeeToDelete��$	��100�� �� 
IsEditable .  �� 
IsReadOnly .  �� Text$! Выберите логин������ $ 	UserNames�# [ �� -	   $
��10 0q�$��30��$��Bottom=�.��20Удалить аккаунт работника