   M S B A M L   `   `   `  ????E  AADOExam2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ADOExam2._0ADOExam2._0  5   	       ADOExam2._0.SearchBook   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ADOExam2._0     5   	     ? 
ResizeMode$  NoResize=?5   	    ? WindowStartupLocation$ CenterScreen=?5	   	    ? Title$ 
DeleteBook??5
   	   $	??620??6   $
??1000??6)    ? 	Resources 5         headingStyle ?? 
TargetType ?? Property ?? Value  tblockStyle  	tboxStyle  btnStyle??%?  &	        &	 ?     &	 ~    &	 t    ?? 5   
   " ??6%   .?5      ??  ? ??$ 17(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   ?? 5       ? ??$ 20q?6'   5      ?? 5   
   " ??6$   .?5      ??  ? ??$ 15(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   5      ?? 5   
   " ??6"   .?5      ??  ? ??$ 15(?6)   ?? 5       ? ??$ Comic Sans MS)?6+   ?? 5       ?@??TextAlignment$ Center=?6.   ?? 5       ? ??$	 250??6&   ?? 5       ? ??$ 30??6'   5      ?? 5   
   " ??6!   .?5       ??  ? ??$ 10q?6'   ?? 5!       ? ??$	 250??6&   ?? 5"       ? ??$ 30??6'   ?? 5#       ? ??$ 15(?6)   ?? 5$       ? ??$ Comic Sans MS)?6+   ?? 5%       ? ??$ 5q?6'   5&      5'      .??5(      ?? .+?5)   
   ?? $??Search book??6   #??[  6'   ?? 5*   
   $-??'Enter book name, author's name or genre??6   #??[ 6C   ?? 5+   
   $??3q?6   ?? 5,   
   -   5        $??bookToSearch??5,      #??[ 6&   ?? 5-   
   $??10q?6   ?? 5.   
   -   5        $??Search by name??5.      #??[ 6?   ?? 5/   
   -   5        $??Search by author??5/      #??[ 6C   ?? 50   
   -   5        $??Search by genre??50      #??[ 6A   ?? 51   
   -   5        $??Close??51      #??[ 62   ?? 52   
   $??10q?6   ?? 53   
   -   5        $??scroll??53      ??. $	??220??6=   .??54      &   System.Windows.Controls.DataGrid  -   5        $??dgFoundBooks??54         CanUserDeleteRows .     CanUserAddRows .  6F   55      56      57      