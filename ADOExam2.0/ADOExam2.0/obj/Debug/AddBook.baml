   M S B A M L   `   `   `  ????E  AADOExam2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ADOExam2._0ADOExam2._0  5   	       ADOExam2._0.AddBook   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ADOExam2._0     5   	     ? 
ResizeMode$  NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5	   	    ? Title$ AddBook??5
   	   $	??900??6   $	??500??6&    ? 	Resources 5         headingStyle ?? 
TargetType ?? Property ?? Value  tblockStyle  	tboxStyle  cbStyle  btnStyle??%n  &	        &	 ?     &	 ~    &	 t    &	 4    ?? 5   
   " ??6%   .?5      ??  ? ??$ 17(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   ?? 5       ? ??$ 20q?6'   5      ?? 5   
   " ??6$   .?5      ??  ? ??$ 15(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   5      ?? 5   
   " ??6"   .?5      ??  ? ??$ 15(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   ?? 5       ? ??$	 300??6&   ?? 5       ? ??$ 25??6'   5      ?? 5   
   " ??6    .?5       ??  ? ??$	 300??6&   ?? 5!       ? ??$ 25??6'   ?? 5"       ? ??$ 13(?6)   ?? 5#       ? ??$ Comic Sans MS)?6+   5$      ?? 5%   
   " ??6!   .?5&      ??  ? ??$ 10q?6'   ?? 5'       ? ??$	 250??6&   ?? 5(       ? ??$ 30??6'   ?? 5)       ? ??$ 15(?6)   ?? 5*       ? ??$ Comic Sans MS)?6+   ?? 5+       ? ??$ 20q?6'   5,      5-      .??5/      ?? .+?50   
   ?? $??Add book??6   #??[  6$   ?? 51   
   $
??Name??6   #??[ 6    ?? 52   
   -   5        $??bookName??52      #??[ 6"   ?? 53   
   $??Series (choose or add)??6   #??[ 62   ?? 54   
   -   5        $??cbSeries??54      #??[ 6#   56      ?? 57   
   -   5        $??
bookSeries??57      #??[ 6$   ?? 58   
   $??Series number??6   #??[ 6)   ?? 59   
   -   5        $??bookSeriesNumber??59      #??[ 6*   ?? 5:   
   $??Genre (choose or add)??6   #??[ 61   ?? 5;   
   -   5        $??cbGenres??5;      #??[ 6#   5=      ?? 5>   
   -   5        $??	bookGenre??5>      #??[ 6#   ?? 5?   
   $??Author (choose or add)??6   #??[ 62   ?? 5@   
   -   5        $??cbAuthor??5@      #??[ 6#   5B      ?? 5C   
   -   5        $??
bookAuthor??5C      #??[ 6$   ?? 5D   
   $??Author's popularity??6   #??[ 6/   ?? 5E   
   -	   5        $??cbAuthorPopularity??5E      #??[ 6.   .@?5F      ?? $??Popular??6   ?? 5G      $??Not popular??6   5H      ?? 5I   
   $??Pages??6   #??[ 6!   ?? 5J   
   -
   5        $??	bookPages??5J      #??[ 6#   ?? 5K   
   $+??%Publication year (Format: 2010-01-01)??6   #??[ 6A   ?? 5L   
   -   5        $??bookPublicationYear??5L      #??[ 6-   ?? 5M   
   $??Publisher (choose or add)??6   #??[ 65   ?? 5N   
   -   5        $??cbPublishers??5N      #??[ 6'   5P      ?? 5Q   
   -   5        $??bookPublisher??5Q      #??[ 6'   ?? 5R   
   $??
Cost price??6   #??[ 6&   ?? 5S   
   -   5        $??bookCostPrice??5S      #??[ 6'   ?? 5T   
   $??Price??6   #??[ 6!   ?? 5U   
   -   5        $??	bookPrice??5U      #??[ 6#   ?? 5V   
   $??Novelty??6   #??[ 6#   ?? 5W   
   -   5        $??cbIsNovelty??5W      #??[ 6&   .@?5X      ?? $
??true??6   ?? 5Y      $??false??6   5Z      ?? 5[   
   $??
Bestseller??6   #??[ 6&   ?? 5\   
   -   5        $??cbIsBestseller??5\      #??[ 6)   .@?5]      ?? $
??true??6   ?? 5^      $??false??6   5_      ?? 5`   
   -   5        $	??Add??5`      #??[ 6.   5a      5b      