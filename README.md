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
- SQL Server
- Dapper
- Postman

## First Screenshots

### Swagger UI Showing Some Endpoints

![](https://lh3.googleusercontent.com/pw/AIL4fc8-ITOnXjt1LIcr-eCex3mTOQiMa75jVLWtdemuZgLmSBkakvweaS2M-Nspp4pCdyLRxPezd0u8NklOgAol2n3bTzWjaU40ZDP0WHQ0rNV-KOQghNk8HXz_lsgSSHlWiMpPpGadA2PB3pDOGtdx-80V=w500-h255-s-no)

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

![](https://photos.google.com/share/AF1QipNfle-R1tIKxxmfUJPtVWVtetwDLZLxFYxeq-udFAo1CiNIbB_PfAa0KbSQvLgGbA?key=d0VkeHFiWjQxV1hHVUNtbmM5MnNrb1JlckQ0UHZ3)