This buildpack lets you override the TimeZone returned by `DateTime.Now` for .NET Framework applications to be something other then that set by host VM. This is intended to be used with `hwc_buildpack`.


## Quick Start

Modify `manifest.yaml` to include the following:

```shell
---
applications:
- name: MyApp
  buildpacks: 
    - https://github.com/macsux/timezone-buildpack/releases/download/v0.1.0/TimezoneBuildpack-win-x64-0.1.0.zip
    - https://github.com/macsux/http-module-loader-buildpack/releases/download/v0.1.0/HttpModuleLoaderBuildpack-win-x64-0.1.0.zip
    - hwc_buildpack
  stack: windows
  env:
    - TIMEZONE: <TimeZoneId>
```

Set timezone by setting `TIMEZONE` environmental variable to the TimeZone ID. These are defined by the host OS. You can get them by calling `TimeZoneInfo.GetSystemTimeZones()` from .NET code. 

Quick reference:

| Id                              | DisplayName                                                  | StandardName                    | DaylightName                    | BaseUtcOffset | SupportsDaylightSavingTime |
| ------------------------------- | ------------------------------------------------------------ | ------------------------------- | ------------------------------- | ------------- | -------------------------- |
| Dateline Standard Time          | (UTC-12:00) International Date Line West                     | Dateline Standard Time          | Dateline Daylight Time          | -12:00:00     | False                      |
| UTC-11                          | (UTC-11:00) Coordinated Universal Time-11                    | UTC-11                          | UTC-11                          | -11:00:00     | False                      |
| Aleutian Standard Time          | (UTC-10:00) Aleutian Islands                                 | Aleutian Standard Time          | Aleutian Daylight Time          | -10:00:00     | **True**                   |
| Hawaiian Standard Time          | (UTC-10:00) Hawaii                                           | Hawaiian Standard Time          | Hawaiian Daylight Time          | -10:00:00     | False                      |
| Marquesas Standard Time         | (UTC-09:30) Marquesas Islands                                | Marquesas Standard Time         | Marquesas Daylight Time         | -09:30:00     | False                      |
| Alaskan Standard Time           | (UTC-09:00) Alaska                                           | Alaskan Standard Time           | Alaskan Daylight Time           | -09:00:00     | **True**                   |
| UTC-09                          | (UTC-09:00) Coordinated Universal Time-09                    | UTC-09                          | UTC-09                          | -09:00:00     | False                      |
| Yukon Standard Time             | (UTC-07:00) Yukon                                            | Yukon Standard Time             | Yukon Daylight Time             | -08:00:00     | **True**                   |
| Pacific Standard Time (Mexico)  | (UTC-08:00) Baja California                                  | Pacific Standard Time (Mexico)  | Pacific Daylight Time (Mexico)  | -08:00:00     | **True**                   |
| UTC-08                          | (UTC-08:00) Coordinated Universal Time-08                    | UTC-08                          | UTC-08                          | -08:00:00     | False                      |
| Pacific Standard Time           | (UTC-08:00) Pacific Time (US & Canada)                       | Pacific Standard Time           | Pacific Daylight Time           | -08:00:00     | **True**                   |
| US Mountain Standard Time       | (UTC-07:00) Arizona                                          | US Mountain Standard Time       | US Mountain Daylight Time       | -07:00:00     | False                      |
| Mountain Standard Time (Mexico) | (UTC-07:00) Chihuahua, La Paz, Mazatlan                      | Mountain Standard Time (Mexico) | Mountain Daylight Time (Mexico) | -07:00:00     | **True**                   |
| Mountain Standard Time          | (UTC-07:00) Mountain Time (US & Canada)                      | Mountain Standard Time          | Mountain Daylight Time          | -07:00:00     | **True**                   |
| Central America Standard Time   | (UTC-06:00) Central America                                  | Central America Standard Time   | Central America Daylight Time   | -06:00:00     | False                      |
| Central Standard Time           | (UTC-06:00) Central Time (US & Canada)                       | Central Standard Time           | Central Daylight Time           | -06:00:00     | **True**                   |
| Easter Island Standard Time     | (UTC-06:00) Easter Island                                    | Easter Island Standard Time     | Easter Island Daylight Time     | -06:00:00     | **True**                   |
| Central Standard Time (Mexico)  | (UTC-06:00) Guadalajara, Mexico City, Monterrey              | Central Standard Time (Mexico)  | Central Daylight Time (Mexico)  | -06:00:00     | **True**                   |
| Canada Central Standard Time    | (UTC-06:00) Saskatchewan                                     | Canada Central Standard Time    | Canada Central Daylight Time    | -06:00:00     | False                      |
| SA Pacific Standard Time        | (UTC-05:00) Bogota, Lima, Quito, Rio Branco                  | SA Pacific Standard Time        | SA Pacific Daylight Time        | -05:00:00     | False                      |
| Eastern Standard Time (Mexico)  | (UTC-05:00) Chetumal                                         | Eastern Standard Time (Mexico)  | Eastern Daylight Time (Mexico)  | -05:00:00     | **True**                   |
| Eastern Standard Time           | (UTC-05:00) Eastern Time (US & Canada)                       | Eastern Standard Time           | Eastern Daylight Time           | -05:00:00     | **True**                   |
| Haiti Standard Time             | (UTC-05:00) Haiti                                            | Haiti Standard Time             | Haiti Daylight Time             | -05:00:00     | **True**                   |
| Cuba Standard Time              | (UTC-05:00) Havana                                           | Cuba Standard Time              | Cuba Daylight Time              | -05:00:00     | **True**                   |
| US Eastern Standard Time        | (UTC-05:00) Indiana (East)                                   | US Eastern Standard Time        | US Eastern Daylight Time        | -05:00:00     | **True**                   |
| Turks And Caicos Standard Time  | (UTC-05:00) Turks and Caicos                                 | Turks and Caicos Standard Time  | Turks and Caicos Daylight Time  | -05:00:00     | **True**                   |
| Paraguay Standard Time          | (UTC-04:00) Asuncion                                         | Paraguay Standard Time          | Paraguay Daylight Time          | -04:00:00     | **True**                   |
| Atlantic Standard Time          | (UTC-04:00) Atlantic Time (Canada)                           | Atlantic Standard Time          | Atlantic Daylight Time          | -04:00:00     | **True**                   |
| Venezuela Standard Time         | (UTC-04:00) Caracas                                          | Venezuela Standard Time         | Venezuela Daylight Time         | -04:00:00     | **True**                   |
| Central Brazilian Standard Time | (UTC-04:00) Cuiaba                                           | Central Brazilian Standard Time | Central Brazilian Daylight Time | -04:00:00     | **True**                   |
| SA Western Standard Time        | (UTC-04:00) Georgetown, La Paz, Manaus, San Juan             | SA Western Standard Time        | SA Western Daylight Time        | -04:00:00     | False                      |
| Pacific SA Standard Time        | (UTC-04:00) Santiago                                         | Pacific SA Standard Time        | Pacific SA Daylight Time        | -04:00:00     | **True**                   |
| Newfoundland Standard Time      | (UTC-03:30) Newfoundland                                     | Newfoundland Standard Time      | Newfoundland Daylight Time      | -03:30:00     | **True**                   |
| Tocantins Standard Time         | (UTC-03:00) Araguaina                                        | Tocantins Standard Time         | Tocantins Daylight Time         | -03:00:00     | **True**                   |
| E. South America Standard Time  | (UTC-03:00) Brasilia                                         | E. South America Standard Time  | E. South America Daylight Time  | -03:00:00     | **True**                   |
| SA Eastern Standard Time        | (UTC-03:00) Cayenne, Fortaleza                               | SA Eastern Standard Time        | SA Eastern Daylight Time        | -03:00:00     | False                      |
| Argentina Standard Time         | (UTC-03:00) City of Buenos Aires                             | Argentina Standard Time         | Argentina Daylight Time         | -03:00:00     | **True**                   |
| Greenland Standard Time         | (UTC-03:00) Greenland                                        | Greenland Standard Time         | Greenland Daylight Time         | -03:00:00     | **True**                   |
| Montevideo Standard Time        | (UTC-03:00) Montevideo                                       | Montevideo Standard Time        | Montevideo Daylight Time        | -03:00:00     | **True**                   |
| Magallanes Standard Time        | (UTC-03:00) Punta Arenas                                     | Magallanes Standard Time        | Magallanes Daylight Time        | -03:00:00     | **True**                   |
| Saint Pierre Standard Time      | (UTC-03:00) Saint Pierre and Miquelon                        | Saint Pierre Standard Time      | Saint Pierre Daylight Time      | -03:00:00     | **True**                   |
| Bahia Standard Time             | (UTC-03:00) Salvador                                         | Bahia Standard Time             | Bahia Daylight Time             | -03:00:00     | **True**                   |
| UTC-02                          | (UTC-02:00) Coordinated Universal Time-02                    | UTC-02                          | UTC-02                          | -02:00:00     | False                      |
| Mid-Atlantic Standard Time      | (UTC-02:00) Mid-Atlantic - Old                               | Mid-Atlantic Standard Time      | Mid-Atlantic Daylight Time      | -02:00:00     | **True**                   |
| Azores Standard Time            | (UTC-01:00) Azores                                           | Azores Standard Time            | Azores Daylight Time            | -01:00:00     | **True**                   |
| Cape Verde Standard Time        | (UTC-01:00) Cabo Verde Is.                                   | Cabo Verde Standard Time        | Cabo Verde Daylight Time        | -01:00:00     | False                      |
| UTC                             | (UTC) Coordinated Universal Time                             | Coordinated Universal Time      | Coordinated Universal Time      | 00:00:00      | False                      |
| GMT Standard Time               | (UTC+00:00) Dublin, Edinburgh, Lisbon, London                | GMT Standard Time               | GMT Daylight Time               | 00:00:00      | **True**                   |
| Greenwich Standard Time         | (UTC+00:00) Monrovia, Reykjavik                              | Greenwich Standard Time         | Greenwich Daylight Time         | 00:00:00      | False                      |
| Sao Tome Standard Time          | (UTC+00:00) Sao Tome                                         | Sao Tome Standard Time          | Sao Tome Daylight Time          | 00:00:00      | **True**                   |
| Morocco Standard Time           | (UTC+01:00) Casablanca                                       | Morocco Standard Time           | Morocco Daylight Time           | 00:00:00      | **True**                   |
| W. Europe Standard Time         | (UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna | W. Europe Standard Time         | W. Europe Daylight Time         | 01:00:00      | **True**                   |
| Central Europe Standard Time    | (UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague | Central Europe Standard Time    | Central Europe Daylight Time    | 01:00:00      | **True**                   |
| Romance Standard Time           | (UTC+01:00) Brussels, Copenhagen, Madrid, Paris              | Romance Standard Time           | Romance Daylight Time           | 01:00:00      | **True**                   |
| Central European Standard Time  | (UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb                 | Central European Standard Time  | Central European Daylight Time  | 01:00:00      | **True**                   |
| W. Central Africa Standard Time | (UTC+01:00) West Central Africa                              | W. Central Africa Standard Time | W. Central Africa Daylight Time | 01:00:00      | False                      |
| Jordan Standard Time            | (UTC+02:00) Amman                                            | Jordan Standard Time            | Jordan Daylight Time            | 02:00:00      | **True**                   |
| GTB Standard Time               | (UTC+02:00) Athens, Bucharest                                | GTB Standard Time               | GTB Daylight Time               | 02:00:00      | **True**                   |
| Middle East Standard Time       | (UTC+02:00) Beirut                                           | Middle East Standard Time       | Middle East Daylight Time       | 02:00:00      | **True**                   |
| Egypt Standard Time             | (UTC+02:00) Cairo                                            | Egypt Standard Time             | Egypt Daylight Time             | 02:00:00      | **True**                   |
| E. Europe Standard Time         | (UTC+02:00) Chisinau                                         | E. Europe Standard Time         | E. Europe Daylight Time         | 02:00:00      | **True**                   |
| Syria Standard Time             | (UTC+02:00) Damascus                                         | Syria Standard Time             | Syria Daylight Time             | 02:00:00      | **True**                   |
| West Bank Standard Time         | (UTC+02:00) Gaza, Hebron                                     | West Bank Gaza Standard Time    | West Bank Gaza Daylight Time    | 02:00:00      | **True**                   |
| South Africa Standard Time      | (UTC+02:00) Harare, Pretoria                                 | South Africa Standard Time      | South Africa Daylight Time      | 02:00:00      | False                      |
| FLE Standard Time               | (UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius    | FLE Standard Time               | FLE Daylight Time               | 02:00:00      | **True**                   |
| Israel Standard Time            | (UTC+02:00) Jerusalem                                        | Jerusalem Standard Time         | Jerusalem Daylight Time         | 02:00:00      | **True**                   |
| Kaliningrad Standard Time       | (UTC+02:00) Kaliningrad                                      | Russia TZ 1 Standard Time       | Russia TZ 1 Daylight Time       | 02:00:00      | **True**                   |
| Sudan Standard Time             | (UTC+02:00) Khartoum                                         | Sudan Standard Time             | Sudan Daylight Time             | 02:00:00      | **True**                   |
| Libya Standard Time             | (UTC+02:00) Tripoli                                          | Libya Standard Time             | Libya Daylight Time             | 02:00:00      | **True**                   |
| Namibia Standard Time           | (UTC+02:00) Windhoek                                         | Namibia Standard Time           | Namibia Daylight Time           | 02:00:00      | **True**                   |
| Arabic Standard Time            | (UTC+03:00) Baghdad                                          | Arabic Standard Time            | Arabic Daylight Time            | 03:00:00      | **True**                   |
| Turkey Standard Time            | (UTC+03:00) Istanbul                                         | Turkey Standard Time            | Turkey Daylight Time            | 03:00:00      | **True**                   |
| Arab Standard Time              | (UTC+03:00) Kuwait, Riyadh                                   | Arab Standard Time              | Arab Daylight Time              | 03:00:00      | False                      |
| Belarus Standard Time           | (UTC+03:00) Minsk                                            | Belarus Standard Time           | Belarus Daylight Time           | 03:00:00      | **True**                   |
| Russian Standard Time           | (UTC+03:00) Moscow, St. Petersburg                           | Russia TZ 2 Standard Time       | Russia TZ 2 Daylight Time       | 03:00:00      | **True**                   |
| E. Africa Standard Time         | (UTC+03:00) Nairobi                                          | E. Africa Standard Time         | E. Africa Daylight Time         | 03:00:00      | False                      |
| Iran Standard Time              | (UTC+03:30) Tehran                                           | Iran Standard Time              | Iran Daylight Time              | 03:30:00      | **True**                   |
| Arabian Standard Time           | (UTC+04:00) Abu Dhabi, Muscat                                | Arabian Standard Time           | Arabian Daylight Time           | 04:00:00      | False                      |
| Astrakhan Standard Time         | (UTC+04:00) Astrakhan, Ulyanovsk                             | Astrakhan Standard Time         | Astrakhan Daylight Time         | 04:00:00      | **True**                   |
| Azerbaijan Standard Time        | (UTC+04:00) Baku                                             | Azerbaijan Standard Time        | Azerbaijan Daylight Time        | 04:00:00      | **True**                   |
| Russia Time Zone 3              | (UTC+04:00) Izhevsk, Samara                                  | Russia TZ 3 Standard Time       | Russia TZ 3 Daylight Time       | 04:00:00      | **True**                   |
| Mauritius Standard Time         | (UTC+04:00) Port Louis                                       | Mauritius Standard Time         | Mauritius Daylight Time         | 04:00:00      | **True**                   |
| Saratov Standard Time           | (UTC+04:00) Saratov                                          | Saratov Standard Time           | Saratov Daylight Time           | 04:00:00      | **True**                   |
| Georgian Standard Time          | (UTC+04:00) Tbilisi                                          | Georgian Standard Time          | Georgian Daylight Time          | 04:00:00      | False                      |
| Volgograd Standard Time         | (UTC+04:00) Volgograd                                        | Volgograd Standard Time         | Volgograd Daylight Time         | 04:00:00      | **True**                   |
| Caucasus Standard Time          | (UTC+04:00) Yerevan                                          | Caucasus Standard Time          | Caucasus Daylight Time          | 04:00:00      | **True**                   |
| Afghanistan Standard Time       | (UTC+04:30) Kabul                                            | Afghanistan Standard Time       | Afghanistan Daylight Time       | 04:30:00      | False                      |
| West Asia Standard Time         | (UTC+05:00) Ashgabat, Tashkent                               | West Asia Standard Time         | West Asia Daylight Time         | 05:00:00      | False                      |
| Ekaterinburg Standard Time      | (UTC+05:00) Ekaterinburg                                     | Russia TZ 4 Standard Time       | Russia TZ 4 Daylight Time       | 05:00:00      | **True**                   |
| Pakistan Standard Time          | (UTC+05:00) Islamabad, Karachi                               | Pakistan Standard Time          | Pakistan Daylight Time          | 05:00:00      | **True**                   |
| Qyzylorda Standard Time         | (UTC+05:00) Qyzylorda                                        | Qyzylorda Standard Time         | Qyzylorda Daylight Time         | 05:00:00      | **True**                   |
| India Standard Time             | (UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi              | India Standard Time             | India Daylight Time             | 05:30:00      | False                      |
| Sri Lanka Standard Time         | (UTC+05:30) Sri Jayawardenepura                              | Sri Lanka Standard Time         | Sri Lanka Daylight Time         | 05:30:00      | False                      |
| Nepal Standard Time             | (UTC+05:45) Kathmandu                                        | Nepal Standard Time             | Nepal Daylight Time             | 05:45:00      | False                      |
| Central Asia Standard Time      | (UTC+06:00) Astana                                           | Central Asia Standard Time      | Central Asia Daylight Time      | 06:00:00      | False                      |
| Bangladesh Standard Time        | (UTC+06:00) Dhaka                                            | Bangladesh Standard Time        | Bangladesh Daylight Time        | 06:00:00      | **True**                   |
| Omsk Standard Time              | (UTC+06:00) Omsk                                             | Omsk Standard Time              | Omsk Daylight Time              | 06:00:00      | **True**                   |
| Myanmar Standard Time           | (UTC+06:30) Yangon (Rangoon)                                 | Myanmar Standard Time           | Myanmar Daylight Time           | 06:30:00      | False                      |
| SE Asia Standard Time           | (UTC+07:00) Bangkok, Hanoi, Jakarta                          | SE Asia Standard Time           | SE Asia Daylight Time           | 07:00:00      | False                      |
| Altai Standard Time             | (UTC+07:00) Barnaul, Gorno-Altaysk                           | Altai Standard Time             | Altai Daylight Time             | 07:00:00      | **True**                   |
| W. Mongolia Standard Time       | (UTC+07:00) Hovd                                             | W. Mongolia Standard Time       | W. Mongolia Daylight Time       | 07:00:00      | **True**                   |
| North Asia Standard Time        | (UTC+07:00) Krasnoyarsk                                      | Russia TZ 6 Standard Time       | Russia TZ 6 Daylight Time       | 07:00:00      | **True**                   |
| N. Central Asia Standard Time   | (UTC+07:00) Novosibirsk                                      | Novosibirsk Standard Time       | Novosibirsk Daylight Time       | 07:00:00      | **True**                   |
| Tomsk Standard Time             | (UTC+07:00) Tomsk                                            | Tomsk Standard Time             | Tomsk Daylight Time             | 07:00:00      | **True**                   |
| China Standard Time             | (UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi            | China Standard Time             | China Daylight Time             | 08:00:00      | False                      |
| North Asia East Standard Time   | (UTC+08:00) Irkutsk                                          | Russia TZ 7 Standard Time       | Russia TZ 7 Daylight Time       | 08:00:00      | **True**                   |
| Singapore Standard Time         | (UTC+08:00) Kuala Lumpur, Singapore                          | Malay Peninsula Standard Time   | Malay Peninsula Daylight Time   | 08:00:00      | False                      |
| W. Australia Standard Time      | (UTC+08:00) Perth                                            | W. Australia Standard Time      | W. Australia Daylight Time      | 08:00:00      | **True**                   |
| Taipei Standard Time            | (UTC+08:00) Taipei                                           | Taipei Standard Time            | Taipei Daylight Time            | 08:00:00      | False                      |
| Ulaanbaatar Standard Time       | (UTC+08:00) Ulaanbaatar                                      | Ulaanbaatar Standard Time       | Ulaanbaatar Daylight Time       | 08:00:00      | **True**                   |
| Aus Central W. Standard Time    | (UTC+08:45) Eucla                                            | Aus Central W. Standard Time    | Aus Central W. Daylight Time    | 08:45:00      | False                      |
| Transbaikal Standard Time       | (UTC+09:00) Chita                                            | Transbaikal Standard Time       | Transbaikal Daylight Time       | 09:00:00      | **True**                   |
| Tokyo Standard Time             | (UTC+09:00) Osaka, Sapporo, Tokyo                            | Tokyo Standard Time             | Tokyo Daylight Time             | 09:00:00      | False                      |
| North Korea Standard Time       | (UTC+09:00) Pyongyang                                        | North Korea Standard Time       | North Korea Daylight Time       | 09:00:00      | **True**                   |
| Korea Standard Time             | (UTC+09:00) Seoul                                            | Korea Standard Time             | Korea Daylight Time             | 09:00:00      | False                      |
| Yakutsk Standard Time           | (UTC+09:00) Yakutsk                                          | Russia TZ 8 Standard Time       | Russia TZ 8 Daylight Time       | 09:00:00      | **True**                   |
| Cen. Australia Standard Time    | (UTC+09:30) Adelaide                                         | Cen. Australia Standard Time    | Cen. Australia Daylight Time    | 09:30:00      | **True**                   |
| AUS Central Standard Time       | (UTC+09:30) Darwin                                           | AUS Central Standard Time       | AUS Central Daylight Time       | 09:30:00      | False                      |
| E. Australia Standard Time      | (UTC+10:00) Brisbane                                         | E. Australia Standard Time      | E. Australia Daylight Time      | 10:00:00      | False                      |
| AUS Eastern Standard Time       | (UTC+10:00) Canberra, Melbourne, Sydney                      | AUS Eastern Standard Time       | AUS Eastern Daylight Time       | 10:00:00      | **True**                   |
| West Pacific Standard Time      | (UTC+10:00) Guam, Port Moresby                               | West Pacific Standard Time      | West Pacific Daylight Time      | 10:00:00      | False                      |
| Tasmania Standard Time          | (UTC+10:00) Hobart                                           | Tasmania Standard Time          | Tasmania Daylight Time          | 10:00:00      | **True**                   |
| Vladivostok Standard Time       | (UTC+10:00) Vladivostok                                      | Russia TZ 9 Standard Time       | Russia TZ 9 Daylight Time       | 10:00:00      | **True**                   |
| Lord Howe Standard Time         | (UTC+10:30) Lord Howe Island                                 | Lord Howe Standard Time         | Lord Howe Daylight Time         | 10:30:00      | **True**                   |
| Bougainville Standard Time      | (UTC+11:00) Bougainville Island                              | Bougainville Standard Time      | Bougainville Daylight Time      | 11:00:00      | **True**                   |
| Russia Time Zone 10             | (UTC+11:00) Chokurdakh                                       | Russia TZ 10 Standard Time      | Russia TZ 10 Daylight Time      | 11:00:00      | **True**                   |
| Magadan Standard Time           | (UTC+11:00) Magadan                                          | Magadan Standard Time           | Magadan Daylight Time           | 11:00:00      | **True**                   |
| Norfolk Standard Time           | (UTC+11:00) Norfolk Island                                   | Norfolk Standard Time           | Norfolk Daylight Time           | 11:00:00      | **True**                   |
| Sakhalin Standard Time          | (UTC+11:00) Sakhalin                                         | Sakhalin Standard Time          | Sakhalin Daylight Time          | 11:00:00      | **True**                   |
| Central Pacific Standard Time   | (UTC+11:00) Solomon Is., New Caledonia                       | Central Pacific Standard Time   | Central Pacific Daylight Time   | 11:00:00      | False                      |
| Russia Time Zone 11             | (UTC+12:00) Anadyr, Petropavlovsk-Kamchatsky                 | Russia TZ 11 Standard Time      | Russia TZ 11 Daylight Time      | 12:00:00      | **True**                   |
| New Zealand Standard Time       | (UTC+12:00) Auckland, Wellington                             | New Zealand Standard Time       | New Zealand Daylight Time       | 12:00:00      | **True**                   |
| UTC+12                          | (UTC+12:00) Coordinated Universal Time+12                    | UTC+12                          | UTC+12                          | 12:00:00      | False                      |
| Fiji Standard Time              | (UTC+12:00) Fiji                                             | Fiji Standard Time              | Fiji Daylight Time              | 12:00:00      | **True**                   |
| Kamchatka Standard Time         | (UTC+12:00) Petropavlovsk-Kamchatsky - Old                   | Kamchatka Standard Time         | Kamchatka Daylight Time         | 12:00:00      | **True**                   |
| Chatham Islands Standard Time   | (UTC+12:45) Chatham Islands                                  | Chatham Islands Standard Time   | Chatham Islands Daylight Time   | 12:45:00      | **True**                   |
| UTC+13                          | (UTC+13:00) Coordinated Universal Time+13                    | UTC+13                          | UTC+13                          | 13:00:00      | False                      |
| Tonga Standard Time             | (UTC+13:00) Nuku'alofa                                       | Tonga Standard Time             | Tonga Daylight Time             | 13:00:00      | **True**                   |
| Samoa Standard Time             | (UTC+13:00) Samoa                                            | Samoa Standard Time             | Samoa Daylight Time             | 13:00:00      | **True**                   |
| Line Islands Standard Time      | (UTC+14:00) Kiritimati Island                                | Line Islands Standard Time      | Line Islands Daylight Time      | 14:00:00      | False                      |