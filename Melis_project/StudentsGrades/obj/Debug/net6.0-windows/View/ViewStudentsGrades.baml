   M S B A M L   `   `   `  ����I  EStudentsGrades, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:StudentsGrades.ViewStudentsGrades.View  5   	   C&clr-namespace:StudentsGrades.ViewModelStudentsGrades.ViewModel  5   	   ,    &StudentsGrades.View.ViewStudentsGrades   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:StudentsGrades.View     5   	   5vm&clr-namespace:StudentsGrades.ViewModel     5   	     � Title$  Students grades��5	   	   $	��450��6!   $	��800��6.    � DataContext 5
      6   0StudentsGrades.ViewModel.StudentsGradesViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Go back��6   $��10q�6�   $��0��6�   ��6#   �� *BackToMainWindowCommand+��6O   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� $��Year:��6   $��Center=�6%   $��5q�6@   �� 5      $	��100��6W   $��5q�6c   ��6   �� *
FilterYear+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5      $��Faculty Number:��6   $��Center=�6/   $��5q�6J   �� 5      $	��200��6`   $��5q�6l   ��6   �� *FilterFacultyNumber+$ PropertyChanged=�6l   �� 5      $��Subject:��6   $��Center=�6(   $��5q�6C   �� 5      $	��100��6Z   $��5q�6f   ��6   �� *FilterSubject+$ PropertyChanged=�6f   �� 5       $��Filter��6   $��5q�6H   ��6&   �� *FilterCommand+6H   �� 5!      $��Clear Filters��6   $��5q�6U   ��6-   �� *ClearFiltersCommand+6U   �� 5"      $��	Add grade��6   $��5q�6T   ��6)   �� *AddStudentGradeCommand+6T   5#      �� 5&   
   $��3��6   $
��Auto=�6$   $
��Auto=�6G   .��5'      �� -   5        $��-2,0,2,0q�5'   r   $	��600��6�   ��6   �� *
Students+ �� Mode$ TwoWay=� �� View 5(      �� 5)      .P�5+      �� $��ID��6)   	 �� DisplayMemberBinding	 65   �� *Id+�� 5,      $��
First Name��6)   	 6=   �� *	FirstName+�� 5-      $��	Last Name��6)   	 6<   �� *
LastName+�� 5.      $��Faculty Number��6)   	 6A   �� *FacultyNumber+�� 50      $��Grades��6)   
 �� CellTemplate
 51      �� 52   "   .R�53   &   �� ��63   �� *Grades+��54   *   �� 55   .   .R�56   2   �� $ 
Horizontal=�6=   .+�57   6   �� $��5q�6Y   ��6@   �� *	Subject+6Y   �� 58   6   $��5q�6W   ��6@   �� *Value+6W   �� 59   6   $��5q�6V   ��6@   �� *Date+6V   �� 5:   6   $��5q�6V   ��6@   �� *Year+6V   5;   3   5<   /   5>   '   5?   #   5A      5B      5D      5E      5F      5G      