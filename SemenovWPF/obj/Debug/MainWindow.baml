   M S B A M L   `   `   `  ����E  ASemenovWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SemenovWPF
SemenovWPF  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 60       SemenovWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SemenovWPF     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     60   -   5          � Title$  Сотрудники��5   	   $	��450��6   $	��800��6)   $	��450��5	   	   $	��800��6   .��5      �� -   5         ��Name$	 tab��5      $
��Left=�6   $	��Top=�6:   $��6��6R   $	��792��6f   $	��419��6r   .@�5   
   �� $��Сотрудники��6   .��5      � ���	#FFE5E5E5$��Stretch=�6*    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $	��100 �6'   .+�5      � $
��Left=�6   $	��Top=�63   �� 5      -   5        $��Добавить��5      $��1��6,   $
��Left=�6<   $��	15,25,0,0q�6W   $	��Top=�6j   $��75��6�   6�   �� 5      -   5         ��Name$ listWorkers��5      ��60   �� *	Workers+ �� View 5      �� 5      .P�5      ��  �� Width$
 auto��6S    �� DisplayMemberBinding 6-   �� *Name+.��6`   Имя6e   �� 5      $
 auto��6V    6-   �� *	Surname+.��6c   Фамилия6l   �� 5      $
 auto��6R    6-   �� *Age+.��6_   Возраст6h   �� 5      $
 auto��6Y    6-   �� *
Department+.��6f   Департамент6s   5      5      �� 5      -   5        $��Удалить��5      $��1��6+   $
��Left=�6;   $��	15,75,0,0q�6V   $	��Top=�6i   $��75��6�    J� RenderTransformOrigin$ -0.027,1.329&�6�   6�   �� 5      -   5        $��Изменить��5      $��1��6,   $
��Left=�6<   $��	15,50,0,0q�6W   $	��Top=�6j   $��75��6�   $ -0.027,1.329&�6�   6�   5       5!      �� 5"   
   $��Департаменты��6   .��5#      � ���	#FFE5E5E5$��Stretch=�6*    5$      �� 5%      $	��17* �6'   �� 5&      $
��326* �6'   �� 5'      $	��100 �6'   .+�5)      � $
��Left=�6   $	��Top=�63   �� 5*      -   5        $��Добавить��5*      $��2��6,   $
��Left=�6<   $��	15,25,0,0q�6W   $	��Top=�6j   $��75��6�   6�   �� 5+      -   5        $ listDeps��5+      $��2��6Q   ��6-   �� *Departments+ 5,      �� 5-      .P�5.      �� $
 auto��6-    6:   �� *Name+.��6`   Наименование6n   5/      51      �� 52      -	   5         ��Name$ Dep_Edit��52      $��Изменить��6+   $��2��6>   $
��Left=�6N   $��	15,50,0,0q�6i   $	��Top=�6|   $��75��6�   6�   53      54      55      56      