//
//  DetailsViewController.swift
//  Fishbook
//
//  Created by Marcel Benders on 09.09.22.
//

import UIKit

class DetailsViewController: UIViewController {
    @IBOutlet weak var pullDownButton: UIButton!
    
    @IBAction func saveClick(_ sender: UIButton) {
        dismiss(animated: true, completion: nil)
    }
    

    @IBAction func cancelClick(_ sender: UIButton){
        dismiss(animated: true, completion: nil)
    }
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        pullDownButton.menu = UIMenu(children: [
            UIAction(title: "Düngung", handler:   {(action) in print("Düngung clicked")
            } ),
            UIAction(title: "Messung", handler: { UIAction in
                print("Messung clicked")
            })])
        // Do any additional setup after loading the view.
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
