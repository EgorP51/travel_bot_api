# Travel api
---
### *The API was created for travel services*
>Initially, the API was developed to work with the telegram bot.You can view the bot project on [GitHub](https://github.com/EgorP51/travel_bot).

## Used in project
- Connecting to public APIs 
- Connecting to a non-relational database Amazon Dynamo DB
- Project deployment on Hiroku

## Features
- Search for information about the city where the traveler wants to go
  -  Search for a picture of the selected city
  -  Short description
  -  Link to wikipedia
  -  Photo
- View the weather for the nearest future in the selected city
  - Minimum and maximum temperature 
  - short description
- Search for a list of hotels according to the parameters specified by the user
  - Link to go to the site for booking hotels 
  - Short description of rooms 
  - List of photos 
  - Hotel coordinates
  - List of amenities 
  - Rating 
  - Prices 
- Connecting to amazon dynamo db database
  - Writing an element to the DB
  - Getting items
  - Update items
  - Removing items

- - -
# Examples of work with api
> *For all requests to public APIs, our API returns json format*
*The city of ***Rome*** is used for the test*
### SearchInfo method
The method accepts the City parameter
City|Rome
---|---


Example of a returned request for the ***GET*** information retrieval method:

```json
{
  "title": "Rome",
  "url": "https://en.wikipedia.org/wiki/Rome",
  "image": "https://upload.wikimedia.org/wikipedia/commons/c/c0/Rome_Montage_2017.png",
  "summary": [
    "Vatican City (the smallest country in the world) is an independent country inside the city boundaries of Rome, the only existing example of a country within a city.",
    "With 2,860,009 residents in 1,285 km2 (496.1 sq mi), Rome is the country's most populated comune and the third most populous city in the European Union by population within city limits.",
    "The host city for the 1960 Summer Olympics, Rome is also the seat of several specialised agencies of the United Nations, such as the Food and Agriculture Organization (FAO), the World Food Programme (WFP) and the International Fund for Agricultural Development (IFAD)."
  ]
}
```
### WeatherControler method
The method accepts the City parameter
City|Rome
---|---


Example of a returned query for the ***GET*** weather search method:
```json
{
  "location": {
    "city": "Rome",
    "country": "Italy",
    "lat": "41.898399",
    "long": "12.4956"
  },
  "forecasts": [
    {
      "day": "Tue",
      "low": "18",
      "high": "32",
      "text": "Sunny"
    },
    {
      "day": "Wed",
      "low": "19",
      "high": "33",
      "text": "Sunny"
    },
    {
      "day": "Thu",
      "low": "18",
      "high": "32",
      "text": "Sunny"
    },
    {
      "day": "Fri",
      "low": "19",
      "high": "35",
      "text": "Sunny"
    },
    {
      "day": "Sat",
      "low": "19",
      "high": "35",
      "text": "Sunny"
    },
    {
      "day": "Sun",
      "low": "20",
      "high": "36",
      "text": "Sunny"
    },
    {
      "day": "Mon",
      "low": "21",
      "high": "36",
      "text": "Sunny"
    },
    {
      "day": "Tue",
      "low": "21",
      "high": "35",
      "text": "Sunny"
    },
    {
      "day": "Wed",
      "low": "21",
      "high": "36",
      "text": "Sunny"
    },
    {
      "day": "Thu",
      "low": "21",
      "high": "35",
      "text": "Sunny"
    },
    {
      "day": "Fri",
      "low": "21",
      "high": "36",
      "text": "Sunny"
    }
  ]
}
```

### CityHotel method
The method accepts parameters: city, check-in date, check-out date and number of people
City|Rome
---|---
Checkin|2022-10-19
Checkout| 2022-10-22
Adults|2


 Example of a return request of the ***GET*** method for searching for a list of hotels:
 ```json
 {
	"results": [{
			"id": "635943522208746500",
			"url": "https://www.airbnb.com/rooms/635943522208746500",
			"deeplink": "https://www.airbnb.com/rooms/635943522208746500?check_in=2022-07-13&check_out=2022-07-17&adults=2&children=0&infants=0",
			"name": "San Pietro Rhome “Estate”",
			"bathrooms": "1",
			"bedrooms": 1,
			"beds": 2,
			"images": [
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/203c3704-48fe-4f25-af35-f5c0b6e52900.jpeg?im_w=720",
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/4e1894f8-1390-40fc-9ec8-49a4606620d2.jpeg?im_w=720",
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/69d8940d-6536-4c9a-a843-2c2be2f47fd5.jpeg?im_w=720",
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/b8f1c84c-786a-401d-9677-7c51e2105bd3.jpeg?im_w=720",
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/4e11024d-2288-4473-b3e7-f4026a39defd.jpeg?im_w=720",
				"https://a0.muscache.com/im/pictures/miso/Hosting-635943522208746449/original/1dd04cd8-7fdb-4266-a915-4593081947b1.jpeg?im_w=720"
			],
			"hostThumbnail": "https://a0.muscache.com/im/pictures/user/736f410b-6a71-41ac-b656-8a18d8ca420c.jpg?aki_policy=profile_x_medium",
			"lat": "41.89887",
			"lng": "12.45151",
			"person": 0,
			"rating": 0,
			"address": "Roma, Lazio, Italy",
			"previewAmenities": [
				"Wifi",
				"Air conditioning",
				"Kitchen",
				"Washer"
			],
			"price": {
				"rate": 133,
				"currency": "USD",
				"total": 531,
				"priceItems": [{
						"title": "$99 x 4 nights",
						"amount": "396"
					},
					{
						"title": "Cleaning fee",
						"amount": "35"
					},
					{
						"title": "Service fee",
						"amount": "72"
					},
					{
						"title": "Occupancy taxes and fees",
						"amount": "28"
					}
				]
			}
		},
		{
			"id": "44258224",
			"url": "https://www.airbnb.com/rooms/44258224",
			"deeplink": "https://www.airbnb.com/rooms/44258224?check_in=2022-07-13&check_out=2022-07-17&adults=2&children=0&infants=0",
			"name": "SUNNY SIDE APARTMENT",
			"bathrooms": "1",
			"bedrooms": 1,
			"beds": 1,
			"images": [
				"https://a0.muscache.com/im/pictures/93f4c3ad-3fd4-4770-b274-b6be17162ca3.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/7ab36fa8-f616-4582-a498-de5a5dafb3e2.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/f1845ac5-5266-4847-9976-a5280c528303.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/6e8064a0-8bdd-4d5c-8177-27dbd3f14f87.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/6ca02f2a-2173-4190-9ff7-8e03bd191f75.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/325365c5-f108-4246-82a2-5b0637d84dac.jpg?im_w=720"
			],
			"hostThumbnail": "https://a0.muscache.com/im/pictures/user/accb7915-9ae0-4574-8949-eedec709e0d0.jpg?aki_policy=profile_x_medium",
			"lat": "41.87629",
			"lng": "12.57979",
			"person": 0,
			"rating": 4.7,
			"address": "Roma, Lazio, Italy",
			"previewAmenities": [
				"Wifi",
				"Air conditioning",
				"Kitchen",
				"Washer"
			],
			"price": {
				"rate": 83,
				"currency": "USD",
				"total": 332,
				"priceItems": [{
						"title": "$55 x 4 nights",
						"amount": "220"
					},
					{
						"title": "Cleaning fee",
						"amount": "40"
					},
					{
						"title": "Service fee",
						"amount": "44"
					},
					{
						"title": "Occupancy taxes and fees",
						"amount": "28"
					}
				]
			}
		},
		{
			"id": "36956793",
			"url": "https://www.airbnb.com/rooms/36956793",
			"deeplink": "https://www.airbnb.com/rooms/36956793?check_in=2022-07-13&check_out=2022-07-17&adults=2&children=0&infants=0",
			"name": "Palazzo Ruspoli Suite",
			"bathrooms": "2.5",
			"bedrooms": 1,
			"beds": 1,
			"images": [
				"https://a0.muscache.com/im/pictures/f0f71ea9-94d1-4f60-a51b-8f397632a16d.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/c2d371ce-ff60-4e7a-b28a-051b24b674c4.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/cdd134cb-d951-4332-9c09-c78d2d7b0317.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/3f2aaafd-d7d8-4a6c-962b-7da529d887be.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/97f788f1-e244-48c2-8bd4-673602308f8d.jpg?im_w=720",
				"https://a0.muscache.com/im/pictures/13f273f0-7218-44ea-8990-a4a4dc0bace1.jpg?im_w=720"
			],
			"hostThumbnail": "https://a0.muscache.com/im/pictures/user/2f4e767c-5fc4-40e1-a1a8-a4df746d849b.jpg?aki_policy=profile_x_medium",
			"lat": "41.90337",
			"lng": "12.47916",
			"person": 0,
			"rating": 4.82,
			"address": "Roma, Lazio, Italy",
			"previewAmenities": [
				"Hosted by a business",
				"Wifi",
				"Air conditioning",
				"Kitchen"
			],
			"price": {
				"rate": 515,
				"currency": "USD",
				"total": 2057,
				"priceItems": [{
						"title": "$495 x 4 nights",
						"amount": "1979"
					},
					{
						"title": "Cleaning fee",
						"amount": "50"
					},
					{
						"title": "Service fee",
						"amount": "0"
					},
					{
						"title": "Occupancy taxes and fees",
						"amount": "28"
					}
				]
			}
		}
	]
}
 ```
 # Database usage
 > The database is used to save, delete and edit **routes**
 > **Routes** are links to google maps with a built route
 > The project uses a non-relativistic database, so access to the elements is carried out through the ID
 
 
#### Example of adding an element to the database:
 
 ****POST*** method to DB accepts json in the format*
 ```json
 { 
 "userId": "783450274",
  "city": "Rome",
  "routes": [
    "https://www.google.com/maps/dir/?api=1&origin=41.893121,12.483314&destination=41.894611,12.486993&travelmode=walking",
    "https://www.google.com/maps/dir/?api=1&origin=41.906107,12.479259&destination=41.90565,12.47969&travelmode=walking"
  ]
}
 ```
 
 #### Example of getting an item from a database
 ****GET*** method accepts the user ID and the selected city*
 *As a result of the work, the method returns json in this format*
 ```json
 { 
 "userId": "783450274",
  "city": "Rome",
  "routes": [
    "https://www.google.com/maps/dir/?api=1&origin=41.893121,12.483314&destination=41.894611,12.486993&travelmode=walking",
    "https://www.google.com/maps/dir/?api=1&origin=41.906107,12.479259&destination=41.90565,12.47969&travelmode=walking"
  ]
}
 ```
#### Example of changing an item in a database
*The first ***PUT*** method accepts json in this format. User ID, selected city and route you want to ***ADD****
```json
{
  "userId": "783450274",
  "city": "Rome",
  "newRoute": "https://www.google.com/maps/dir/?api=1&origin=41.893121,12.456334&destination=41.894611,12.486993&travelmode=walking"
}
```
*The second ***PUT*** method accepts json in this format. User ID, selected city and route you want to ***DELETE****
```json
{
  "userId": "783450274",
  "city": "Rome",
  "routeToDelete": "https://www.google.com/maps/dir/?api=1&origin=41.89376651,12.456334&destination=41.894611,12.486993&travelmode=walking"
}
```
#### Example of deleting item from the database
****DELETE*** method takes user id and city and deletes item from database*
UserId | 783450274
---|---
City | Rome
---
