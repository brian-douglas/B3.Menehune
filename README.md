# B3 Menehune
Simple chaos monkey style plugin to ASPNetCore.    Good for checking kubernetes probes (e.g., livenessProbe) or similar 



### What's a menehune?

https://en.wikipedia.org/wiki/Menehune



### Usage

The menehune sleeps until you wake him up.  Wake him up with:

`POST request to:  https://[YOUR APP URL]/MenehuneState/Random`



Check its current running state with:

`GET request to:  https://[YOUR APP URL]/MenehuneState`



If you don't like random stuff, you can enforce the following chaos strategies:

`POST request to:  https://[YOUR APP URL]/MenehuneState/Return500Error`

`POST request to:  https://[YOUR APP URL]/MenehuneState/NeverReturn`



Or put the menehune back to sleep with:

`POST request to:  https://[YOUR APP URL]/MenehuneState/SleepingPassThrough`





### Set up

1. add nuget package [B3.Menehune](https://www.nuget.org/packages/B3.Menehune/) to your ASPNetCore 2.2+ web project

2. in Startup.cs, add the following to the Configure() method, before use.Mvc() or similar middleware:

   `app.UseMenehune();`



### Using with livenessProbe in Kubernetes

- Add a livenessProbe with httpGet to your kubernetes deployment, like:

  ```yaml
  livenessProbe:
    httpGet:
       path: /api/health
       port: 80
     initialDelaySeconds: 20
     periodSeconds: 5
  ```

  *(where /api/health is some kind of health check URL -- could be anything else that returns 200 when successful)*

- When your aspnet web service first starts, menehune is in the default sleeping state

- Activate one of the chaos strategies via POST call

- Watch kubernetes restart your pod and then menehune goes back to sleep



<img src="https://raw.githubusercontent.com/brian-douglas/B3.Menehune/master/B3-Logo-256.png" width="48" />

