# auto-repair-shop-api

## Description

The Automotive Workshop Software API will provide a set of endpoints to interact with the automotive workshop management system. This API is designed to serve WPF (Windows Presentation Foundation) and Mobile applications.

## Features 

### Mechanic Operations: 

Mechanics using Mobile apps can perform assigned car inspections, complete reports, and post messages to the message wall with different tags for communication with managers.

### Manager Operations: 

Managers using WPF apps can search, view, and update customer and vehicle details, assign job cards/inspections to mechanics, manage incoming appointments, view completed inspections, update stock/inventory, and access a dashboard with essential data.

## Technology Stack
- C#
- ASP.NET Web API
- JWT Authentication and Authorisation
- SQL Server
- Dapper
- Postman

## Screenshots

### Swagger UI Showing Some Endpoints

![](https://lh3.googleusercontent.com/pw/AIL4fc_CDUE4PmCWQpFwwGNK6zslr892LNteGTfm3mtGfdxBhKZxhOP1ZZANp3Jp0ImLRl_tXueWQdU_mNsEQ0w5wMmQwh69HX27tdJ7AMg28YZZP9zZxCqMacTOqTgL_3CPG6EdAsdWPsM1qP0SdyjRc8BS=w1866-h952-s-no)

### Now Testing From Postman

### Get All Customers 

![](https://lh3.googleusercontent.com/pw/AIL4fc8HXoqd98uQ241Yj1_pqonkhXTOAshTj3sLgwSauWZKEgWfvq2viaYoYWoYZmEJhogxExNDvt7Lo-W4XTlVN2_RSti6FKfkLPqIvEwhTAIoxCVB1-IEt0c4A3BzVVQ4SjkmTXxRhXWyIGcf3yT27NqO=w1162-h963-s-no)

### Get A Single Customer By Id

![](https://lh3.googleusercontent.com/pw/AIL4fc9nbfQETbE6AGAG-yKwJSMTDEu0H-qe5tVR1VLlZ6WU74jnOyACeUFet3SCg2iTavxZ-pelATPkrJBX6-wulg4jc6Q6Z0zjCdi7IyLvOwCH-3CuLkGHptC3Mz-vG0zBYefkvmEWXQSjN_-3hmqAvFYE=w609-h530-s-no)

### Create A New Customer

![](https://lh3.googleusercontent.com/pw/AIL4fc-cjCnNRaYa2aHEFRdT2YO0RseORx4V05ZHrpIJC4Oc1c-6K_fki38fNO8E72RBW6jS-LCJzKjwhbkCotdEuBD6hD2F1iTE9jqTO8umYJ7VF3SJRavK8s6iE_WpN6s837FMO8sG2lTpt6zxaNMJUzRt=w666-h525-s-no)

![](https://lh3.googleusercontent.com/pw/AIL4fc9HzLPVOQTC_pc9JzayhXG53mMDWs8-k5H9ylbU9n4683PdmC2td_piLP5cB0v-My06bGYBGe08m00Cf93tHqPYa-xQ78jNXWy8zTqulnzojzT6aIfbxhdvkSZaS-tr7QIribojvMuxEUxFMFIsh-DZ=w627-h470-s-no)

### Update An Existing Customer

#### Returning 400 When Ids Don't Match

![](https://lh3.googleusercontent.com/pw/AIL4fc_6EwM8lYEzGx3ZxcdL5v_nIn8iHzM3vaqwIThv1UtZzWokGsVwv0pSfPicR_GMj8FbOeyNA9717tI-K-8dwa123fv3QBxOEGF0XpkRn0Bh4PTmjRgjARFoxYrzGopxZ_0HpEVncbZraJWo28-qhFxB=w544-h541-s-no)

![](https://lh3.googleusercontent.com/pw/AIL4fc_FGX1nmODTd0fMAmXUzACG7v8YkMuygWC4YXEhbpiSE2JSnfIUc5IZDmblJrM_odnC949TlCGX0qHDvfZ-pprkP0CTS_8xSDQWDQlRe_pmOI_z-D9tJ4rg25XsfyhThg06wUM0lzkAHrdmUt8nK8Vs=w567-h547-s-no)

![](https://lh3.googleusercontent.com/pw/AIL4fc-OQEMIH43DSfRS17R7F0219mPBGnEQGceAI18ipzR-sxs26uOfkutm-_-yyFxa8U-ds_1IXrXcAtmKAIQskcP8vwAnNasr1-IrlLm6V8fJI0dgUoG1lGQDmfVRmusHTzmZz0lXEoaXy78jefr_qBsz=w534-h429-s-no)

### Delete A Customer

![](https://lh3.googleusercontent.com/pw/AIL4fc_mtXS9guY91BdodT192KulpkgYxQXw2biQMIQ99vlE7IZzG5oCsQDcP0eiReTpu39AxCX9WXSLgCYe3VsGK-qI3hdqLQvnZhYW00-TYehSEWFrnYOF7Sy6dTJeTmukI8KAl51cUXi_b9SWCPSjh-V0=w546-h414-s-no)

## Authentication and Authorisation

The API uses the Log In information from the Web App to verify users (checking email and password), creates a token with their roles and sends it back to the user to access the allowed endpoints.

Trying to access and endpoint (other than the token generator) without a valid token will return 401 Unauthorized.
![](https://lh3.googleusercontent.com/pw/AIL4fc9tXA0r0t6ozyAIgydI-KdXNpP5WX3eo69CW3v7ZljhCTucvm8bA4WmX58CXNm5noXU__avkVWz_76OiQi7XUKbbtKkzldtaWGW8fekGK-B4mH2MmC9G5iAJfjvakwnd_yLnGltLtnSEdddoDonoVCx=w1018-h421-s-no)

Trying to access and endpoint without a valid token generated for a Mechanic to a Manager-Only endpoint will return 403 Forbidden.
![](https://lh3.googleusercontent.com/pw/AIL4fc-P2ZVO9NjTdDJfSKeTK8eGNetoWKRKqzcRfE4nnlPP-9e4vBeNhhVnS8IeULjTN2Oq51cTmjcanSJWcLiaMBIqfI7KxI6xOM9uXHlhFnnM0h-on4r4ioQa6_NW6aNmq77xt4zuLiVX3K3PSy3iT1Of=w1062-h600-s-no)

Creating a token using the login details through Asp.Net Identity User Manager will automatically retrieve the user role from the database to add this information to the token
![](https://lh3.googleusercontent.com/pw/AIL4fc9TBIb23GFJCkjQpVxyBI52fldHTLKFb3PQkjAgiohsPdXvgIOoh1y8ZTFJQHy1hFyGmYRsOJJkMaqAWVY3j1UAGjaWUtsFZ102syF1Hfl-I0Q4ETgtrhBy39HE_SoQddq_Dc_PBJYf_LQuBfO7sOTS=w772-h753-s-no)

That generated token will now give the user access to the allowed endpoints considering their role
![](https://lh3.googleusercontent.com/pw/AIL4fc9lvhYm9t-8KekMwlzvjRruVxnbm5RJLz_rE40snrne_h6fBU0J1OKdj1BLzbflkyDO5-S8fXQNdj7cZ88TT6dT4NjtqHfpgwmrA5bxCYGLQ_ZvGZQRUs6eSiIZC5x7TOznsstdpwNevhRcnO13Nf0l=w1165-h882-s-no)