   M S B A M L   `   `   `  ����?  ;Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Test.Pages
Test.Pages  5          Test.Pages.RegPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Test.Pages     5        N� Title$  RegPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   �� 
���   �$��1q�6'   $��Профиль��6;   $
��Bold"�6L   .��5      �  5      �� 5      $
��Auto �6'   �� 5       5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      ��    DefaultTextBlock#��[  6   $��
Почта��6F   6U   �� 5      #��[  6   $��Пароль��6F   $��1��6T   6c   �� 5       -   5        $��TbEmail��5    i     DefaultTextBox#��[ 6   $��1��6B   ��6R   �� *Email+6z   �� 5!      -   5        $��
TbPassword��5!   _   #��[ 6   $��1��6B   $��1��6O   ��6q   �� *
Password+6�   5"      5#      �� 5$   
   
���   �$��1q�6'   $'��!Паспортные данные��6;   $
��Bold"�6V   $��1��6h   .��5%      �  � DataContext 6   �� *PassportData+ 5&      �� 5'      $
��Auto �6'   �� 5(       5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      .+�52      �� #��[  6   $��Фамилия��6F   6W   �� 53      #��[  6   $��1��6F   $��Имя��6S   6`   �� 54      #��[  6   $��2��6F   $��Отчество��6S   6e   �� 55      #��[  6   $��3��6F   $��
Серия��6S   6b   �� 56      #��[  6   $��4��6F   $��
Номер��6S   6b   �� 57      #��[  6   $��5��6F   $��Дата выдачи��6S   6h   �� 58      -   5        $��
TbLastName��58      #��[ 6,   $��1��6T   ��6d   �� *
LastName+6�   �� 59      -   5        $��TbFirstName��59      #��[ 6-   $��1��6U   $��1��6e   ��6r   �� *	FirstName+6�   �� 5:      -   5        $��TbMiddleName��5:      #��[ 6.   $��1��6V   $��2��6f   ��6s   �� *
MiddleName+6�   �� 5;      -   5        $��TbSeries��5;      #��[ 6*   $��1��6R   $��3��6b   ��6o   �� *Series+6�   �� 5<      -   5        $��TbNumber��5<      #��[ 6*   $��1��6R   $��4��6b   ��6o   �� *Number+6�   (  "System.Windows.Controls.DatePicker  5=      -   5        $��DpIssues��5=        DefaultDatePicker#��[ 6-   $��1��6X   $��5��6h      SelectedDate 6u   �� *DateOfIssue+   Text 6�   �� *DateOfIssue+ �� StringFormat$ 
dd/MM/yyyy��6�   5>      5?      �� 5@   
   -	   5        $��Submit��5@   U     DefaultButton#��[ 6   $��1��68   $��1��6H   $��Подтвердить��6x   6�   5A      5B      