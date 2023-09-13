# AspNet & SSMS practice

### Mapping a web app for practice :penguin:

Web app in AspNet, using C#'s MapGet to map routes landing into pages, sending data to the application, requesting data from local SQL server and showing the processed data (and testing some other features).

## Routes
|      \\...      |                     Destination                        |
|-----------------|--------------------------------------------------------|
|                 | Hello World!                                           |
| products        | redirect to html page                                  |
| clients         | use http parameters (name & email) and return the data |
| customersupdate | update customer's attributes (parameters: id & name)   |
| customers       | return the data of the Customer instance               |
| api             | return customer's data in json format                  |
| htmlTest        | render the customer's data in a html page              |
| bank            | render local SQL server table's data in a html page    |

Tnx4 reading.
