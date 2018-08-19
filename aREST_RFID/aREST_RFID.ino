// Import required libraries
#include <MFRC522.h>
#include <SPI.h>
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>
#include <aREST.h>

#define SS_PIN    15
#define RST_PIN   5
 
#define SIZE_BUFFER     18
#define MAX_SIZE_BLOCK  16
// MFRC522::MIFARE_Key key;
//código de status de retorno da autenticação
//MFRC522::StatusCode status;
 
// Definicoes pino modulo RC522
MFRC522 mfrc522(SS_PIN, RST_PIN); 
 
// Status
int status = WL_IDLE_STATUS;

// Create aREST instance
aREST rest = aREST();

// WiFi parameters
char ssid[] = "";
char password[] = "";

// The port to listen for incoming TCP connections
#define LISTEN_PORT           80

// Create an instance of the server
WiFiServer server(LISTEN_PORT);
int getID();
int ledOn(String command) {digitalWrite(4, HIGH);}
int ledOff(String command) {digitalWrite(4 ,LOW);}
// Variables to be exposed to the API
float lightLevel;
String readme = "";
void setup(void)
{
  pinMode(4, OUTPUT);
  SPI.begin();
  mfrc522.PCD_Init(); 
  // Start Serial
  Serial.begin(115200);

  // Init variables and expose them to REST API
  rest.variable("rfid_uid",&readme);
  rest.function("ledOn",ledOn);
  rest.function("ledOff", ledOff);
  
  // Give name and ID to device
  rest.set_id("1");
  rest.set_name("robozito_web");

  // Connect to WiFi
  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to SSID: ");
    Serial.println(ssid);
    status = WiFi.begin(ssid, password);

    // Wait 10 seconds for connection:
    delay(10000);
  }
  Serial.println("WiFi connected");

  // Start the server
  server.begin();
  Serial.println("Server started");
 
  // Print the IP address
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);
}

void loop() {

  // Measure light level
  getID();
  // Handle REST calls
  WiFiClient client = server.available();
  if (!client) {
    return;
  }
  while(!client.available()){
    delay(1);
  }
  rest.handle(client);
  readme="";
}


 int getID() {
  // Getting ready for Reading PICCs
  if ( ! mfrc522.PICC_IsNewCardPresent()) { //If a new PICC placed to RFID reader continue
    return 0;
  }
  if ( ! mfrc522.PICC_ReadCardSerial()) { //Since a PICC placed get Serial and continue
    return 0;
  }
  // There are Mifare PICCs which have 4 byte or 7 byte UID care if you use 7 byte PICC
  Serial.println("Scanned PICC's UID:");
  readme = "";
  for (int i = 0; i < mfrc522.uid.size; i++) {
    readme += String(mfrc522.uid.uidByte[i], HEX);
  }
  Serial.print(readme);
  Serial.println("");
  mfrc522.PICC_HaltA(); // Stop reading
  return 1;
}
