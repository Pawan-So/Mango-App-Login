# Mango-App-Login
This project is a WPF Desktop applicaton based on MVVM architecture.This is used to authenticate user credentials by consuming a rest web api.IF user logged in successfully,it will prompt user for success else an error window will be displayed.
The UI is responsive means all the user controls can take the form of screen size.
The initial main winodw has a fixed size 600*475 but can be adjust accordingly.
The Login ID(Min 4 & Max 100 char/Case insensitive and valid email id) and password field(Min 5 and Max 25 chars) has some validations and for that validations it used IDataErrorInfo notification.
The UI event is handled using ICommand archietecture in WPF.It used a Action delegate based relay command and can refer to any UI event
at run time.
