# Megventory-API
This is a web application based Megventory API.
Project technology : ASP. Net MVC

# To run this project : 
First you have to create an account in this website : 
```
www.megaventory.com .
```
Afterwards, you have to create an APIKEY,here is guide  : 
```
http://help.megaventory.com/en/articles/74873-how-do-i-get-started-with-the-api
```
The APIKEY shall be used along with the base URL which is : 
```c#
const string BASE_URL = "https://api.megaventory.com/v2017a/";
```
The APIKEY should be replaced in the code with your own,this web app doesnot cover all endpoints but some manner and proccess go with the rest.

## the relation of this project with another project of mine
I have worked before on a project which was an android movie app based app where i have to parse json to string by making Json requests either object request or array one,sometimes both of them at the same time, the only difference is that in this project i had to parse objects to string,in otherwords we say **Serialization** and **deserialization **.

The Get Http method,get all suplier clients : 
![app](/images/index.png)
