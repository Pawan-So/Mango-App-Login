   M S B A M L   `   `   `  ����E  AMangoLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MangoLogin
MangoLogin  5          MangoLogin.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:MangoLogin     5        � DataContext  5	         MangoLogin.LoginViewModel  5
   
    � 	Resources 5         TextErrorStyle �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path  PasswordErrorStyle��%n  &	        &	 �    �� 5   
   " ��6'    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent��� 5       �@=�ErrorTemplate 5      �� 5      TextErrorTemplate��.R�5   "   ]� .+�5   &   �� 
���  ��$��1q�6?   ._�5   *   �� 5   '   �� 5   &   $��20(�60   
���  ��6>   5   #   5      5      5      5!      �� 5"   
   " G�6+    5#      P� 5$       �@=�HasError . . �5%      ��  �@�ToolTip 60   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent��� 5'       �@=�ErrorTemplate 5(      �� 5)      TextErrorTemplate��.R�5*   "   ]� .+�5+   &   �� 
���  ��$��1q�6?   ._�5,   *   �� 5-   '   �� 5.   &   $��20(�60   
���  ��6>   5/   #   50      52      53      55      56      .��57      �� 
������� �� CornerRadius$ 20��6    $��10q�62   ._�58   
   �� $
��Auto=�6   $
��Auto=�6:   .��59      �  � RowDefinitions 5:      �� 5;      $��40 �6$   �� 5<      $��50 �6$   �� 5=      $��* �6$   �� 5>      $��40 �6$   �� 5?      $��40 �6$    � ColumnDefinitions 5A      �� 5B      .+�5D      �� $��40��6   $��0��6%   ���	#FF15ADE2.+�5E      �� $��MangoApps for Windows��6   $��0,5,0,0q�6<   
�������$��Center=�6`   $��40��6}    �� Left$ 5��6�   $��Center=�6�   �� 5F      -   5        $��btnMinimize��5F       �� Right$ 45��60    � ToolTip$ Minimize��6B   $��0,10,0,0q�6�   
������ $��Right=�6  $��14��6*  $��14��66  ��6U   �� *MinimizeBtnClick+��6z   �� 	 �� *FindAncestor+ �� AncestorType" ���5G      �� 5H       �� ImageSource$ Asset/minimize.png��6)   5J      �� 5K      -   5        $��btnClose��5K      $ 15��6-   $ Close��6?   $��0,10,0,0q�6�   
������ $��Right=�6  $��14��6!  $��14��6-  ��6O   �� *CloseBtnClick+��6q   �� 	 �� *FindAncestor+" ���5L      �� 5M      $ Asset/close.png��6)   5O      5P      �� 5Q      $��1��6   $��50��6%   $	��350��61   $��Center=�6=   $��Center=�6Z   $��Asset/ms_header.PNG��6u   �� 5R       �� Orientation$ Vertical=�6   $��2��64   .+�5S      �� $��Login ID��6   ���	#FF15ADE26/   �� 5T      -   5        $��
txtUsrName��5T      $��15(�60   $��25��6>   #��[  6J   $��2q�6r   ��6�   �� *_LoginModel.UserName+ �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=��� 5U      $��Password��6   ���	#FF15ADE26/   G� 5V      -   5        $��
MyPassword��5V   "   $��15(�64   #��[ 6B   $��25��6n   $��2q�6z   6�   �� 5W      $ 
Horizontal=�6!   .+�5X      �� $��
Domain URL��6    ���	#FF15ADE265   �� 5Y      $��Asset/info.png��6    $��13��68   $��13��6D   5Z      �� 5[      -   5        $��txtDomainURL��5[      $��15(�62   $��25��6@   $��2q�6L    �� 
IsReadOnly . ��6X   �� *_LoginModel.TxtDomainName+$ PropertyChanged=�6�   �� 5\      $ 
Horizontal=�6!   $��5q�6:   .+�5]      �� $��Remember me��6#   ���	#FF15ADE2$ 20��6P   
 �� Top$ 10��6a   $��Right=�6q   �� 5^      $��Asset/info.png��6    $��13��68   $��13��6D   $��4,0,0,0q�6O   5_      �� 5`      -   5        $��	btnSignIn��5`      $��Stretch=�6.   
�������$��30��6_   $��SIGN IN��6�   $��Center=�6�   ���	#FF15ADE2��6k   �� *SubmitBtnClicked+{�6�   �� *IsSignInBtnEnabled+6�   5a      �� 5b      $��Stretch=�6   $��3��67   $��33��6D   .��5c      � $��Stretch=�6   $��Bottom=�69    5d      �� 5e      �� 5f      .+�5h      �� $
��Left=�6    $��0��6;   $��Asset/loginButtonLock.png��6K   $��20��6n   �� 5i      $��1��6    $!��Sign In using other Methods��60   5j      5k      �� 5l      $��4��6   ���	#FF15ADE2$��Center=�6A    �� Padding$ 10q�6^   �� 5m      .�6   Sign Up for MangoApps63   5n      5o      5p      5q      5r      