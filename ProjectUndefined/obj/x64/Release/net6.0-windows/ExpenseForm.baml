   M S B A M L   `   `   `  ���� K  GProjectUndefined, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjectUndefinedProjectUndefined  "    ProjectUndefined.ExpenseForm   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:ProjectUndefined     -     �Name$  MainWindowTemplate�� � Title$ Add Expense��$	��450��$	��301��$��Consolas)�
���   �.��� .+��� -    ��Name$ homeBudgetCT��.@��� -    ��Name$ 
ExpenseTab��$��Expenses��$��
-2,-2,-4,0q�.��� -    �Name$ expenseGrid�� � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* ��� $
��1.4* � � ColumnDefinitions �� $
��0.2* ��� $
��0.2* ��� $��* ��� $
��0.5* ��� $��* ��� $
��0.2* ��� $
��0.2* �.+��� $��27(�$
��Bold"� �� TextAlignment$ Center=�$��Center=�$��0��$��2��$��3��$��0,6,1,0q�Enter Expense�� -    ��Name$
 Menu��$��0,6,0,34q�$��5��$��2��$	��NaN��	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� �� 
 �� AngleX$
 0Q��� T�  T� X$ 0Q�.@��� -    ��Name$ DarkMode��.��	Dark Mode�� -   $ 	LightMode��.��
Light Mode�� -   $ Ocean��.��Ocean�� -	   $ GreenMix��.��Mix of Green�� -
   $ Sunset��.��Sunset�� $��1��$��2��$��3��.+��� $��10(��� $�Category���� -   $ cmbCategories���� $��2��$��2��$��3��.+��� $��10(�Date(  "System.Windows.Controls.DatePicker  -     Name$ 
datePicker��   IsTodayHighlighted$
 True���� $��3��$��2��$��3��.+��� $��10(�Description�� -    ��Name$ txtDescription��$��40��$��13(��� $��4��$��2��$��3��.+��� $��10(�Amount�� -   $ 	txtAmount��$��13(��� -    ��Name$ chkIsCredit��$	��0,3q�.��	Credit?�� -    ��Name$ btnAddExpense��$��5��$��1��$��2��$
��Bold"�.��Add Expense�� -   $ btnCancelExpense��$��5��$��4��$��2�����	#FFCC6666.��Cancel�� $��6��$��2��$��3��$	��0,3q�.+��� $��10(�$
��Bold"�Last Action:�� -    ��Name$ txtLastAction��$��10(�-none�� -   $ CatTab��$��Category��$��4,-2,0,0q�$
��Left=�$��70��.��� -   $ catGrid�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* ��� $
��0.5* ��� $
��0.9* � �� $
��0.2* ��� $
��0.2* ��� $��* ��� $
��0.5* ��� $��* ��� $
��0.2* ��� $
��0.2* �.+��� -   $ 
MenuUpdate��$��0,6,0,34q�$��5��$��2��$	��NaN��$	 0.5,0.5&�z�V� .~��� �� $
 0Q��� T� $ 0Q�.@��� -   $ 	DarkMode1��.��	Dark Mode�� -   $ 
LightMode1��.��
Light Mode�� -   $ Ocean1��.��Ocean�� -   $ 	GreenMix1��.��Mix of Green�� -   $ Sunset1��.��Sunset�� $��24(�$
��Bold"�$ Center=�$��Center=�$��0��$��2��$��3��$��0,6,1,0q�Add New Category�� -   $ txtCategory��$��10,10,10,10q�$��2��$��3��$��2��$��1���� $��57,108,0,300q�$
��Left=�$��1��Category Type�� -   $ 
catTypeBox��$��10,10,10,10q�$��2��$	 0.226,0.488&�$��3��$��3��z�V� .~���  �� ScaleX$ 1Q��� �� T� �� -   $ cmbcategoriescollection��$��2��$��4��$��3��$��1��$��10,10,10,10q��� -   $ btnAddCategory��$��Add Category��$��5��$��1��$��2��$
��Bold"��� -   $ btnCancelCategory��$��Cancel��$��5��$��4��$��2�����	#FFCC6666�� -    $ bthDeleteCategory��$��Delete��$��6��$��4��$��2��$
��Bold"��� -!   $ UpdateExpense��$��	0,-2,-1,0q�$��Update��$��Right=�$��70��.��� -"   $ UpdateExpenseGrid�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.5* ��� $
��1.4* � �� $
��0.2* ��� $
��0.2* ��� $��* ��� $
��0.5* ��� $��* ��� $
��0.2* ��� $
��0.2* �.+��� $��27(�$
��Bold"�$ Center=�$��Center=�$��0��$��2��$��3��$��0,6,1,0q�Update Expense�� -#   $ MenuCats��$��0,6,0,34q�$��5��$��2��$	��NaN��$	 0.5,0.5&�z�V� .~��� �� $
 0Q��� T� $ 0Q�.@��� -$   $ 	DarkMode2��.��	Dark Mode�� -%   $ 
LightMode2��.��
Light Mode�� -&   $ Ocean2��.��Ocean�� -'   $ 	GreenMix2��.��Mix of Green�� -(   $ Sunset2��.��Sunset�� $��1��$��2��$��3��.+��� $��10(�
Category�� -)   $ cmbCategoriesUpdate���� $��10(�
Expense ID�� -*   $ cmbExpId��$��15���� $��2��$��2��$��3��.+��� $��10(�Date  -+   $ datePickerUpdate��$
 True���� $��3��$��2��$��3��.+��� $��10(�Description�� -,   $ txtDescriptionUpdate��$��40���� $��4��$��2��$��3��.+��� $��10(�Amount�� --   $ txtAmountUpdate���� -.   $ chkIsCreditUpdate��$	��0,3q�.��	Credit?�� -/   $ btnAddExpenseUpdate��$��5��$��1��$��2��$
��Bold"�.��Update Expense�� -0   $ btnCancelExpenseUpdate��$��5��$��4��$��2�����	#FFCC6666.��Cancel�� $��6��$��2��$��3��$	��0,3q�.+��� $��10(�$
��Bold"�Last Action:�� -1   $ txtLastActionUpdate��$��10(�-none�� -2   $ btnDeleteExpense��$��6��$��4��$��2��$��1��$
��Bold"�.��Delete Expense