   M S B A M L   `   `   `  ����D  @CineTrack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CineTrack	CineTrack  5   	       CineTrack.DetailsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CineTrack     5   	   $	��450��5   	   $	��800��6     � WindowStyle$
  None=�5	   	    � 
ResizeMode$ NoResize=�5
   	   
������  � AllowsTransparency . .��5      �� ���#272537 �� CornerRadius$ 20��6"   ._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    .+�5      � -   5        $��0��5      
������ .+�5      �� $��Détails��6   $��22(�5      
�������$
��Left=�5      $��Center=�5      $��20,0,0,0q�5      $��/Fonts/#Poppins)�5      �� 5       -   5        $��X��5       $��30��5!      $��30��5"      $��Right=�5#      $��Center=�5$      $��0,0,20,0q�5%      
������ 
������ 
�������$��16(�5)      $
��Bold"�5*      5+      5,      � 5/      $��1��6   $��10q�6     � ColumnDefinitions 50      �� 51      $
��Auto �6'   �� 52      $��* �6'   .+�55      �� $	��200��66   $	��300��6B   $��10q�6O   ��6   �� *
PosterPath+6O   �� 56      $��1��6   $��10q�6-   .+�57      �� $
��Bold"�67   $��24(�6I   ��6    �� *Title+6I   �� 58      $��Italic$�6=   $��18(�6P   ��6    �� *ReleaseYear+6P   �� 59      $
��Wrap=�6:   $��16(�6N   ��6    �� *
Overview+6N   �� 5:      $��16(�68   ��6    �� *Rating+68   �� 5;      $��16(�6<   ��6    �� *
MainActors+6<   �� 5<       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��10q�6W   .+�5=      �� -   5        $��À voir��5=   !   $��5q�6N   �� 5>      -   5        $��En cours��5>   !   $��5q�6S   �� 5?      -   5        $��	Déjà vu��5?   !   $��5q�6O   5@      5A      5C      5D      5E      5F      