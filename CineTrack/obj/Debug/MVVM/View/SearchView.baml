   M S B A M L   `   `   `  ����D  @CineTrack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CineTrack.MVVM.ViewCineTrack.MVVM.View  5      $    CineTrack.MVVM.View.SearchView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:CineTrack.MVVM.View     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6V   .+�5      �� -   5         ��Name$ 	SearchBox��5      $	��300��6)   $��40��65   $��Center=�6A   $��5q�5      |�.  �� AcceptsReturn .    ModernTextbox#��[  5      �� 5      -   5        $��
Rechercher��5      $	��100��6*   $��40��66   $��10,0,0,0q�6B   5      5      �� 5   
   -   5         ��Name$ ResultsList��5      $��1��6W   $��10q�6d   ��5      �� 5      .R�5      �� 
�������$��1q�65   $��5q�6I    �� Padding$ 10q�6T    �� CornerRadius$ 5��6a   ._�5      �� $ 
Horizontal=�6%   .+�5      �� $��80��6B   $	��120��6M   $��5q�6Z   ��6$   �� *
PosterPath+6Z   �� 5      .+�5   "   �� $
��Bold"�6C   $��16(�6U   ��6,   �� *Title+6U   �� 5    "   $��Italic$�6I   $��14(�6\   ��6,   �� *ReleaseYear+6\   �� 5!   "   
�������$��14(�6Y   ��6,   �� *	MediaType+6Y   5"      5#      5$      5%      5'      5(      5)      