# Better

ASP.NET Core MVC project includes:

    - Logging (using Serilog)
    - Global Exception Handling Middleware
    - Generics
    - Swagger
    - Unit Tests (xUnit)
    - Moq (for Unit testing)
    - Data Validators

Endpoints Accepts a JSON request:

  POST: /Bets
  body:
        {
          "eventId": 123,
          "odd": 1.4,
          "playerId": 12456,
          "price": 50.01111111111111
        }

  GET: /Bets/Logs
  body:
        [
            {
                "betId": 71,
                "eventId": 123,
                "oddId": 1,
                "resultCode": "Ongoing"
            }
        ]

  Main Data Structures:
  
          EVENT LIST
      
        	{
        		"Id": 123,
        		"IsLive": true,
        		"StartTime": "2024-01-16T12:00:00",
        		"Odds": [
        			{
        				"Id": 1,
        				"Value": 1.5
        			},
        			{
        				"Id": 2,
        				"Value": 2.0
        			}
        		]
        	},
        	{
        		"Id": 124,
        		"IsLive": false,
        		"StartTime": "2024-01-17T15:30:00",
        		"Odds": [
        			{
        				"Id": 3,
        				"Value": 2.3
        			},
        			{
        				"Id": 4,
        				"Value": 1.8
        			}
        		]
        	},
        	{
        		"Id": 125,
        		"IsLive": true,
        		"StartTime": "2024-01-18T18:45:00",
        		"Odds": [
        			{
        				"Id": 5,
        				"Value": 1.7
        			},
        			{
        				"Id": 6,
        				"Value": 2.5
        			}
        		]
        	}
        ]
  
        PLAYER LIST
        
        [
          {
            "Balance": 74.2,
            "Id": 78901
          },
          {
            "Balance": 0.0,
            "Id": 34567
          },
          {
            "Balance": 73.2,
            "Id": 78901
          },
          {
            "Balance": 51.1,
            "Id": 12456
          }
        ]
  
        BET LOG
  
        {
          "eventId": 123,
          "odd": 1.4,
          "playerId": 12456,
          "price": 50.01111111111111
        }

      
