Feature: Search Locations
	In order to improve my geographical info
	As a user
	I want to know the location details based on country and zipcode
	
@api
Scenario Outline: Check location country name, placename, and state based on zip code and country abbreviation
	Given I want to know the info of <countryAbb> with <zipCode>
	When I retrieve the data of that location
	Then Country name should be <countryName>
    And Place name should be <placeName>
    And State should be <state>
Examples:
|countryAbb |zipCode|countryName|placeName  |state          |
|NL         |2274   |Netherlands|Voorburg   |Zuid-Holland   |
|HR         |53296  |Croatia    |Metajna    |Ličko-Senjska  |


