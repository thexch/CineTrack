   M S B A M L   `   `   `  ����D  @CineTrack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CineTrack	CineTrack  5   	   C&clr-namespace:CineTrack.MVVM.ViewModelCineTrack.MVVM.ViewModel  5   	       CineTrack.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CineTrack     5   	   <	viewModel&clr-namespace:CineTrack.MVVM.ViewModel     5   	   $	��600��5	   	   $	��920��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5      ,  &CineTrack.MVVM.ViewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5       � RowDefinitions 5      �� 5      $��50 �6    �� 5      .+�5!      � -   5        $��2��5!      
������ $��0��6[   .+�5"      �� $��	CineTrack��6   $��22(�5#      
�������$
��Left=�5%      $��Center=�5&      $��20,0,0,0q�5'      $��/Fonts/#Poppins)�5(      �� 5+      -   5        $��X��5+      $��30��5,      $��30��5-      $��Right=�5.      $��Center=�5/      $��0,0,20,0q�50      
������ 
������ 
�������$��16(�54      $
��Bold"�55      56      57      �� 59      $��1��6   .+�5:      	� $
��Home��6   $��50��5;      
�������$��14(�5=         MenuButtonTheme#��[  5>       d� 	IsChecked$
 TrueY�5?      ��5@      �� *HomeViewCommand+	� 5B      $��	Recherche��6   $��50��5C      
�������$��14(�5E      #��[  5F      ��5G      �� *SearchViewCommand+	� 5I      $��A voir��6   $��50��5J      
�������$��14(�5L      #��[  5M      ��5N      �� *TowatchViewCommand+	� 5O      $��En cours��6   $��50��5P      
�������$��14(�5R      #��[  5S      ��5T      �� *InProgressViewCommand+	� 5U      $��	Déjà vu��6   $��50��5V      
�������$��14(�5X      #��[  5Y      ��5Z      �� *WatchedViewCommand+5[      �� 5]      $��1��6   $��1��5^      $��10q�5_      ��5`      �� *CurrentView+5a      5b      5c      