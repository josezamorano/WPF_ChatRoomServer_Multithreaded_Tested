   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PresentationLayer.MVVM.ViewsPresentationLayer.MVVM.Views  5   	   U/clr-namespace:PresentationLayer.MVVM.ViewModels!PresentationLayer.MVVM.ViewModels  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5	   	   1    +PresentationLayer.MVVM.Views.MainWindowView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;view*clr-namespace:PresentationLayer.MVVM.Views     5   	   E	viewModel/clr-namespace:PresentationLayer.MVVM.ViewModels     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fLfa_sharp=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   Cfa_wpf6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF  5	   	     � Title$  MainWindowView��5   	   $	��550��5   	   $	��300��5   	   $	��900��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      ResizeBorderThickness$ 5q�6)    � 	Resources 5       �� DataType?   9PresentationLayer.MVVM.ViewModels.SingleChatRoomViewModel5   /PresentationLayer.MVVM.Views.SingleChatRoomView=   7PresentationLayer.MVVM.ViewModels.AllChatRoomsViewModel3   -PresentationLayer.MVVM.Views.AllChatRoomsView?   9PresentationLayer.MVVM.ViewModels.AllServerUsersViewModel5   /PresentationLayer.MVVM.Views.AllServerUsersView7   1PresentationLayer.MVVM.ViewModels.ServerViewModel-	   'PresentationLayer.MVVM.Views.ServerView��%,  (��       5      *, +)(�� 2     5       *, +)(�� d     5$      *, +)(�� �     5(      *, +)�� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!        5"      �� 5$   
   "  6   .R�5%        5&      �� 5(   
   "  6   .R�5)      	  5*      5-      .��5/      �� $��Disabled=�50   	   $
��Auto=�51   	   .��53   
   �� 	 �� CornerRadius$	 5��54      $��3q�55      
 J� Opacity$
 1Q�56      ��58      �� 59       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5:      �    panelborderWhite � Color# [  6#    � Offset$ 0Q�6M   � 5;        panelborderBlue_IV# [ 6#   $
 0.35Q�6O   � 5<        panelborderBlue_VI# [ 6#   $
 0.75Q�6O   � 5=        panelborderBlue_I# [ 6#   $ 1Q�6N   5>      ._�5A      �  � RowDefinitions 5B      �� 5D      $��40 �6$   �� 5F      $
��Auto �6$   �� 5H      $��* �6$   ��5K      �� 5L      $ 0.5,0&�6*   $ 0.5,1&�6=   .��5M      �   panelBackgroundGrey_XII# [ 6'   � 5N        panelBackgroundGrey_XIV# [ 6'   $	 0.3Q�6X   � 5O        panelBackgroundGrey_XV# [ 6'   $	 0.6Q�6W   � 5P        panelBackgroundGrey_XVI# [ 6'   $	 0.9Q�6X   5R      .+�5T      �� $��0��6   
���  ��$��0q�68   �� 5U      $��1��6   
��� � �$��0q�6:   �� 5V      $��2��6   
��� ���$��0q�6;   �� 5Y      -   5         ��Name$ WindowControlPanel��5Y      $��0��5Z       �� Orientation$ 
Horizontal=�5[      $��RightToLeft=�5\      
������ $��0,0,0,0q�5^      .+�5b      �� -   5         ��Name$ ButtonClose��5b        windowPanelButtonCorner#��[ 5c      .��5f      !
  FontAwesome.Sharp.IconImage
  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Xmark=�6-    	 windowPanelIcon#��[	 6:   5g      �� 5i      -   5        $ ButtonMaximize��5i       
 windowPanelButton#��[
 5j      .��5m      
  $ Square=�6-   #��[	 6;   5n      �� 5p      -   5        $ ButtonMinimize��5p      #��[
 5q      .��5t      
  $ WindowMinimize=�6-   #��[	 6D   5u      5v      �� 5{      -   5         ��Name$" ScrollviewerMenuPanelbuttons��5{      $��1��5|      $
��Auto=�5}      $��Disabled=�5~      .��5�      � -   5         �Name$  GridHeaderMenuPanelButtons��5�      $��1��5�      y�5�      �� *&$GridHeaderMenuPanelButtonsVisibility+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� � ColumnDefinitions 5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5�      	� -   5         	�Name$ ButtonConnection��5�   &   $��1��5�   !   $��Center=�5�   !     MenuPanelRadioButton#��[ 5�   !   ��5�   !   �� *OpenServerViewCommand+.��5�      �� $ 
Horizontal=�6)   $��LeftToRight=�6B   $��Center=�5�   )   $��Stretch=�6D   .+�5�   "   
  $ Server=�65     MenuPanelIcon#��[ 6C   �� 5�   "   $��Server��6,   $��14(�6:   $��10,4,0,0q�6H   5�      5�      	� 5�      -   5        $ ButtonServerUsers��5�   &   $��3��5�   !   #��[ 5�   !   ��5�   !   �� * OpenAllServerUserstViewCommand+.��5�      �� $ 
Horizontal=�6)   $��LeftToRight=�6B   $��Center=�5�   )   $��Right=�6D   .+�5�   "   
  $ Users=�65     MenuPanelUsersIcon#��[ 6B   �� 5�   "   $��Users��6,   $��14(�69   $��10,5,0,0q�6G   5�      5�      	� 5�      -	   5        $ ButtonChatRooms��5�   &   $��5��5�   %   #��[ 5�   %   ��5�   %   �� *OpenAllChatRoomsViewCommand+.��5�      �� $ 
Horizontal=�6)   $��LeftToRight=�6B   $��Center=�5�   )   $��Right=�6D   .+�5�   "   
  $ Comments=�65     MenuPanelCommentsIcon#��[ 6E   �� 5�   "   $��
Chat Rooms��6,   $��14(�6>   $��10,5,0,0q�6L   5�      5�      5�      5�      �� 5�      -
   5         ��Name$ ContentControlChildViews��5�   !   $��2��5�      ��5�      �� *CurrentChildView+5�      5�      5�      5�      