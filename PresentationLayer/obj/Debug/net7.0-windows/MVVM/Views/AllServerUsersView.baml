   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PresentationLayer.MVVM.ViewsPresentationLayer.MVVM.Views  5      5    /PresentationLayer.MVVM.Views.AllServerUsersView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PresentationLayer.MVVM.Views     5      .��5	      �� -   5          ��Name$  BorderAllUsersListView��5	      
���  ��$��0q�6?   ._�5   
   � -   5         �Name$ GridAllUsersListView��5      $	��top=�6-   .+�5      �� -   5         ��Name$ ListViewAllUsers��5      
������     panelBackgroundBrushGrey_III#��[  5      $	��410��5      ��5      �� *ItemsSourceAllUsers+ �� SelectedItem 5      �� *SelectedItemUser+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value   panelBackgroundBrushGrey_XVI��%@  '��       '�� �     7  �� 5      " ��6   .�5      ��  �@��CornerRadius$ 5��69   �� 5       � ��
 �����69   �� 5       � ��$ 5q�6<   5      �� 5      " ��6    5      P� 5      	 �@��
IsSelected$

 True��6<   . �5   "   ��  � ��8   6?   5      5       5"      ��5#      �� 5$      " ��6   .�5%      ��  � ��$ Stretch=�6G    5&      P� 5'      	 �@��
IsSelected$

 True��6<   . �5(   "   ��  � ��# [ 6?   5)      5+      ��5.      �� 5/      .R�50      ��    panelBackgroundBrushGrey_VII#��[ 6!   $��3q�51   !    �� CornerRadius$ 5��52   !   ._�54      � $ GridListViewItems��6#   $��Stretch=�55   #   #��[ 56   #    � ColumnDefinitions 58   "   �� 59   &   $��4* �67   �� 5:   &   $��4* �67   �� 5;   &   $��2* �67    � RowDefinitions 5=   "   �� 5>   &   $��* �64   �� 5?   &   $��* �64   �� 5@   &   $��* �64   �� 5A   &   $��* �64   .+�5D   "   ��  ��Name$ TitleUsername��6,   $��0��5E   ,   $��0��69   $��Username��5F   ,     standardTextBlock#��[ 5G   ,   $
��Left=�5H   ,   $��Center=�5I   ,   $��10,0,0,0q�5J   ,   
���   �5K   ,   �� 5M   "   $ TitleClientID��6,   $��0��5N   ,   $��1��69   $��	Client ID��5O   ,   #��[ 5P   ,   $
��left=�5Q   ,   $��Center=�5R   ,   $��5,0,0,0q�5S   ,   
���   �5T   ,   �� 5V   "   $ TitleIsConnected��6,   $��0��5W   -   $��2��6:   $��IsConnected��5X   -   #��[ 5Y   -   $
��left=�5Z   -   $��Center=�5[   -   $��5,0,0,0q�5\   -   
���   �5]   -   �� 5_   "   $ TextUsername��6,   $��1��5`   ,   $��0��69   #��[ 5b   ,   $��12(�5c   ,   $
��left=�5d   ,   $��Center=�5e   ,   $��10,0,0,0q�5f   ,     panelborderBrushBlue_V#��[ 5g   ,   ��5a   ,   �� *
Username+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5g   ,   �� 5i   "   $ 
TextUserID��6,   $��1��5j   ,   $��1��69   #��[ 5l   ,   $
��left=�5m   ,   $��Center=�5n   ,   $��12(�5o   ,   $��5,0,0,0q�5p   ,   #��[ 5q   ,   ��5k   ,   �� *UserId+$ TwoWay=�$ PropertyChanged=�5q   ,   �� 5s   "   $ TextIsConnected��6,   $��1��5t   -   $��2��6:   #��[ 5v   -   $��Center=�5w   -   $��Center=�5x   -   $��5,0,0,0q�5y   -   #��[ 5z   -   ��5u   -   �� *IsConnected+$ TwoWay=�$ PropertyChanged=�5z   -   �� 5|   "   $ TitleLocalEndpoint��6,   $��2��5}   -   $��0��6:   $��Local Endpoint��5~   -   #��[ 5   -   $
��Left=�5�   -   $��Center=�5�   -   $��10,0,0,0q�5�   -   
���   �5�   -   �� 5�   "   $ TextLocalEndpoint��6,   $��3��5�   -   $��0��6:   #��[ 5�   -   $
��left=�5�   -   $��Center=�5�   -   $��10,0,0,0q�5�   -   #��[ 5�   -   ��5�   -   �� *LocalEndpoint+$ TwoWay=�$ PropertyChanged=�5�   -   �� 5�   "   $ TitleRemoteEndpoint��6,   $��2��5�   -   $��1��6:   $��Remote Endpoint��5�   -   #��[ 5�   -   $
��Left=�5�   -   $��Center=�5�   -   $��5,0,0,0q�5�   -   
���   �5�   -   �� 5�   "   $ TexRemotelEndpoint��6,   $��3��5�   -   $��1��6:   #��[ 5�   -   $
��left=�5�   -   $��Center=�5�   -   $��5,0,0,0q�5�   -   #��[ 5�   -   ��5�   -   �� *LocalEndpoint+$ TwoWay=�$ PropertyChanged=�5�   -   5�      5�      5�      5�      5�      5�      5�      