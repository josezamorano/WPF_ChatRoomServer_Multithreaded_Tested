   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PresentationLayer.MVVM.ViewsPresentationLayer.MVVM.Views  5      3    -PresentationLayer.MVVM.Views.AllChatRoomsView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PresentationLayer.MVVM.Views     5      .��5	      �� -   5          ��Name$  BorderAllItemsListView��5	      
���  ��$��0q�6?   ._�5
   
   � -   5         �Name$ GridAllItemsListView��5
      $	��Top=�6-   y�5      �� *GridAllChatRoomsVisibility+.+�5      �� -   5         ��Name$ ListViewAllItems��5      
������     panelBackgroundBrushGrey_III#��[  5      $	��400��5      ��5      �� *ItemsSourceAllChatRooms+ �� SelectedItem 5      �� *SelectedItemChatRoom+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value   panelBackgroundBrushGrey_XVI��%@  '��       '�� �     7  �� 5      " ��6   .�5      ��  �@��CornerRadius$ 5��69   �� 5       � ��
 �����69   �� 5       � ��$ 5q�6<   5      �� 5      " ��6    5      P� 5      	 �@��
IsSelected$

 True��6<   . �5   "   ��  � ��8   6?   5      5       5"      ��5$      �� 5%      " ��6   .�5&      ��  � ��$ Stretch=�6G    5'      P� 5(      	 �@��
IsSelected$

 True��6<   . �5)   "   ��  � ��# [ 6?   5*      5,      ��5.      �� 5/      .R�50      ��    panelBackgroundBrushGrey_VII#��[ 6!   $��3q�51   !    �� CornerRadius$ 5��52   !   ._�55      � $ GridListViewItems��6#   $��Stretch=�56   #   #��[ 57   #    � ColumnDefinitions 59   "   �� 5:   &   $��2* �67   �� 5;   &   $��8* �67    � RowDefinitions 5=   "   �� 5>   &   $��* �64   �� 5?   &   $��* �64   �� 5@   &   $��* �64   �� 5A   &   $��* �64   �� 5B   &   $��* �64   .+�5E   "   ��  ��Name$ TitleChatRoomName��6,   $��0��5F   ,   $��0��69   $��ChatRoom Name: ��5G   ,     standardTextBlock#��[ 5H   ,   $��Right=�5I   ,   $��Center=�5J   ,   $��0,0,2,0q�5K   ,   
���   �5L   ,   �� 5N   "   $ TextChatRoomName��6,   $��0��5O   ,   $��1��69   #��[ 5Q   ,   $
��left=�5R   ,   $��Center=�5S   ,   $��5,0,0,0q�5T   ,   
���   ���5P   ,   �� *ChatRoomName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5U   ,   �� 5W   "   $ TitleChatRoomID��6,   $��1��5X   ,   $��0��69   $	��ID:��5Y   ,   #��[ 5Z   ,   $��Right=�5[   ,   $��Center=�5\   ,   $��0,0,5,0q�5]   ,   
���   �5^   ,   �� 5`   "   $ TextBoxChatRoomID��6,   $��1��5a   ,   $��1��69   #��[ 5c   ,   $
��left=�5d   ,   $��Center=�5e   ,   $��5,0,0,0q�5f   ,   
���   ���5b   ,   �� *
ChatRoomId+$ TwoWay=�$ PropertyChanged=�5g   ,   �� 5i   "   $ TitleChatRoomStatus��6,   $��2��5j   -   $��0��6:   $��Status:��5k   -   #��[ 5l   -   $��Right=�5m   -   $��Center=�5n   -   $��0,0,2,0q�5o   -   
���   �5p   -   �� 5r   "   $ TextChatRoomStatus��6,   $��2��5s   ,   $��1��69   #��[ 5u   ,   $
��left=�5v   ,   $��Center=�5w   ,   $��5,0,0,0q�5x   ,   
���   ���5t   ,   �� *ChatRoomStatus+$ TwoWay=�$ PropertyChanged=�5y   ,   �� 5{   "   $ TitleTotalGuests��6,   $��3��5|   ,   $��0��69   $��Active Users:��5}   ,   #��[ 5~   ,   $��Right=�5   ,   $��Center=�5�   ,   $��0,0,5,0q�5�   ,   
���   �5�   ,   �� 5�   "   $ TextBoxTotalGuests��6,   $��3��5�   ,   $��1��69   #��[ 5�   ,   $
��left=�5�   ,   $��Center=�5�   ,   $��5,0,0,0q�5�   ,   
���   ���5�   ,   �� *AllActiveUsersInChatRoomCount+$ TwoWay=�$ PropertyChanged=�5�   ,   5�      5�      5�      5�      5�      5�      5�      