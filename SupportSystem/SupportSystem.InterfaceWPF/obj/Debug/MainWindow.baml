   M S B A M L   `   `   `  ����M  ISupportSystem.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcDclr-namespace:SupportSystem.Core.Commons;assembly=SupportSystem.CoreSupportSystem.Core.Commons  5       SupportSystem.InterfaceWPF+   %SupportSystem.InterfaceWPF.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]DevExpress.Xpf.Core.v14.1, Version=14.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      RcommonsDclr-namespace:SupportSystem.Core.Commons;assembly=SupportSystem.Core  5        � Title$  
MainWindow��5	      $��435.572��6   $��685.199��6)    � 	Resources 5
      ;  5DevExpress.Xpf.Core.DataSources.IEnumerableDataSource   IEnumerableDataSource7  1DevExpress.Xpf.Core.DataSources.DesignDataManager   
DesignData8  2DevExpress.Xpf.Core.DataSources.DesignDataSettings   RowCount   DataObjectType M� TypeName��%�   &	          5   
    5        5      $ 5��6(    5      M� 5      $ commons:ProblemRatio��6!   5      5      5      .��5      � .+�5   
   &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ MainTabControl��5      $��0,0,-0.333,0q�62   $��Stretch=�6H   $��Stretch=�5      $��0q�6=   .@�5      #  DevExpress.Xpf.Core.DXTabItem     Header)  #DevExpress.Xpf.Core.ObjectConverter$	 Tab 6   .��5      � $��0,0,0,0q�6   ���	#FF3F3F3F � ColumnDefinitions 5      �� 5      $	��69* �6+   �� 5      $
��267* �6+   �� 5      $
��Auto �6+   �� 5       $
��343* �6+   .+�5#      �� -   5        	 ��Name$	 Preset1Button��5#      $��Button��64   $
��Left=�6E   $��1,60,0,0q�6`   $	��Top=�5$      $	��115��65   $��35��6A   $��2��5%      5&      5'        5(      -   5        
  Name$
 QuestionsTab��5(      $	 Tab 61   .��5)      � ���	#FF3F3F3F$��0,0,-0.333,0q�6.   .+�5*      �� -   5         ��Name$ QuestionTextLabel��5*      $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�5+      $��77��64   $	��659��6@   $��Times New Roman)�6L   $��18(�6i   ���	#00000000
�������.��5-      �� -   5         ��Name$ QuestionTextBlock��5-   $   $��WrapWithOverflow=�6?   �� 5.      $@�:Текс вопроса отображется здесь?��6"   5/      50      �� 51      -   5        $	 YesAnswerButton��51      $
��Да��66   $
��Left=�6C   $��	10,92,0,0q�6^   $	��Top=�52      $	��151��65   $��55��6A    J� RenderTransformOrigin$ 0.506,0.558&�6M   53      �� 54      -   5        $	 NoAnswerButton��54      $��Нет��65   $
��Left=�6C   $��
182,92,0,0q�6^   $	��Top=�55      $	��151��65   $��55��6A   $ 0.506,0.558&�6M   56      �� 57      -   5        $	 SkipAnswerButton��57      $��Пропустить��67   $
��Left=�6L   $��
366,92,0,0q�58      $	��Top=�61   $	��151��6I   $��55��6U   $ 0.506,0.558&�59      6A   �� 5:      -	   5         ��Name$ ProblemsListBox��5:      $
��Left=�68   $	��156��6S   $��0,225,-0.333,0q�6`   $	��Top=�5;      $	��679��67    �� DisplayMemberPath$ DisplayValue��6C   
����������	#FF3F3F3F��5<   6   Z� ��5=      �� 5>       �� 
TargetType" ��6$    �� Triggers 5?   "   P� 5@   &    P� Property �@J�IsMouseOver P� Value . . �5A   *   ��  �� Property � �� �� Value
 ���� 6G   �� 5B   *    � ��
 ���� 6H   5C   '   P� 5D   &    �@��
IsSelected . . �5E   *   ��  � ��
 ���� 6G   �� 5F   *    � ��
 ���� 6H   5G   '   5I       �� View 5K      �� 5L      .P�5M   "   �� 5N      5P      5Q      5R        5S      $	 Tab 6   .��5T      � ���	#FF3F3F3F.+�5U      �� -
   5        $ ProblemShortNameLabel��5U      $
��Left=�6;   $��0,23,0,0q�6V   $	��Top=�5V      $��94��64   $	��669��6@   $��Times New Roman)�6L   $��22(�6i   
�������.��5X      �� -   5        $ ProblemTextBlock��5X   $   $��WrapWithOverflow=�6>   5Y      �� 5Z      -   5        $	 ProblemSolvedButton��5Z      $#��Проблема решена��6:   $
��Left=�6T   $��
16,162,0,0q�5[      $	��Top=�61   $	��151��6I   $��55��6U   $ 0.506,0.558&�5\      6A   �� 5]      -   5        $	 WrongProblemButton��5]      $'��!Неверная проблема��69   $
��Left=�6U   $��188,162,0,0q�5^      $	��Top=�62   $	��151��6J   $��55��6V   $ 0.506,0.558&�5_      6A   5`      5a        5b      $	 Tab 6   .��5c      � -   5         �Name$ SuccessTabPage��5c      ���	#FF3F3F3F.+�5d      �� $
��Left=�6   $��	10,62,0,0q�67   $	��Top=�6J   
�������$��Times New Roman)�5e      $��22(�69   .��5f      ��  �� TextAlignment$ Center=�6$   $��WrapWithOverflow=�6;   $	��652��6[   �� 5g      $���Благодарим Вас за использование автоматизированной службы поддержки!��6"   5h      5i      5j      5k        5l      $	 Tab 6   .��5m      � ���	#FF3F3F3F.+�5n      �� $
��Left=�6   $��	10,62,0,0q�67   $	��Top=�6J   
�������$��Times New Roman)�5o      $��22(�69   .��5p      �� -   5        $ NextLinePage��5p   $   $ Center=�6:   $��WrapWithOverflow=�6Q   $	��652��5q   $   �� 5r      $���Ваш инцидент направлен специалисту службы поддержки для дальнейшего рассмотрения��5s   !   5t      5u      5v      5w        5x      $	 Tab 6   .��5y      �� $��Button��6   $��99��6*   $��75��66   5z      5{      5}      5~      