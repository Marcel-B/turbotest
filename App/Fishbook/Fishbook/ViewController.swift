//
//  ViewController.swift
//  Fishbook
//
//  Created by Marcel Benders on 08.09.22.
//

import UIKit
struct Item : Codable {
    let appUser: String?
    let datum: String
    let id: String
    let liter: Int
    let name: String
    let userId: String
}
struct FeedItem: Codable {
    let aquaType: String
    let datum: String
    let id: String
    let item: Item
    
}
struct GroupedFeed: Codable {
    let datum: String
    let feedItems: [FeedItem]
}

struct ToDoResponseModel: Codable {
    let total: Int
    let groupedFeeds: [GroupedFeed]
}

class ViewController: UIViewController, UITableViewDelegate, UITableViewDataSource  {
    let lolo = ["Kaiser", "Reto"];
    let url = URL(string: "http://localhost:5046/api/feed/grouped?page=1&days=7")
    
    @IBOutlet weak var table: UITableView!
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return lolo.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "call", for: indexPath)

        // Configure the cell...
        cell.textLabel?.text = lolo[indexPath.row]
        return cell
    }
    

    func parseJSON(data: Data) -> ToDoResponseModel? {
        var returnValue: ToDoResponseModel?
         do {
             returnValue = try JSONDecoder().decode(ToDoResponseModel.self, from: data)
         } catch {
             print("Error took place\(error.localizedDescription).")
         }
         
         return returnValue
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
        self.table.delegate = self
        self.table.dataSource = self
        
        guard let requestUrl = url else {fatalError()}
        
        var request = URLRequest(url: requestUrl)
        request.httpMethod = "GET"
        request.setValue( "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjdGMkJFM0EwNEQyMzk1Q0JDRjk2MzI2RTFBRTRBNkQ3RUY2RURFNEEiLCJ4NXQiOiJmeXZqb0UwamxjdlBsakp1R3VTbTEtOXUza28iLCJ0eXAiOiJhdCtqd3QifQ.eyJzdWIiOiJiZjc1NjNlYy1hNTgxLTQ0ZGItOTUzYy1mMWY4OGM0Y2JlYzAiLCJlbWFpbCI6Im1hcmNlbC5iZW5kZXJzQG91dGxvb2suZGUiLCJuYW1lIjoibWFyY2VsLmJlbmRlcnNAb3V0bG9vay5kZSIsIm9pX3Byc3QiOiJmaXNoYm9vay5jbGllbnQiLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYwNjUvIiwib2lfYXVfaWQiOiIwNDBlMDk4NS00OGY1LTQ5ZTctYjE5NS1jYWY3MTA3MGM3ZDUiLCJjbGllbnRfaWQiOiJmaXNoYm9vay5jbGllbnQiLCJvaV90a25faWQiOiI4ZTE0NmRjMS01YThkLTRlZTMtOTk5Yy04ZjdiYjczOGRmZTMiLCJzY29wZSI6Im9wZW5pZCIsImp0aSI6IjQxNWNmNDcyLWRhMjctNGNlMi05YTZlLWQ4ODQzYWI1YWU0YiIsImV4cCI6MTY2MjcwOTA2MSwiaWF0IjoxNjYyNzA1NDYxfQ.hpp0ujKTmYmkiRr4fK1FjrQAhrZRP7VCLP1LvdM3zPUC9HkmqpPr5hwg1X3xUrqlKHyj3mIoj5Xi0JOMUv75QcqX1Q5EHNY1MwYIKzP3OlegiLWaB0riNnVVYUBq9R43BggB_offVVuKMBNXc7zmzZJriWiXbKALD492deKdcD_AdqEvktgjQfh6ua0y-Sz99FbbJN4ZyPzVvsFOQVE1QEa9ieeVjjrZUiOtVpNkoT3LxGbKKueXBkD-dicS2cPRqfB9a6TJi_0j6ft0AXu-e5Zpa3qA5rnz_TTt7rswc6Xurmlx0EzYjSKP34umpLQrY2IX4_HDbxL4X3B4jba6bg", forHTTPHeaderField: "Authorization")
        let task = URLSession.shared.dataTask(with: request) {(data, response, error) in
            if let error = error {
                print("Error took place \(error)")
                       return
            }
            
            if let response = response as? HTTPURLResponse {
                 print("Response HTTP Status code: \(response.statusCode)")
             }
             
             // Convert HTTP Response Data to a simple String
            
                 guard let data = data else { return }
                 // Using parseJSON() function to convert data to Swift struct
            let todoItem = self.parseJSON(data: data)
                     
                 // Read todo item title
                 guard let todoItemModel = todoItem else { return }
                 print("Todo item title = \(todoItemModel.total)")
            //self.lolo = totoItemModel.
        }
        task.resume()
        
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
