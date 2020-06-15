// IFC2XML.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <ifcpp/reader/ReaderSTEP.h>


 #include <utility>


int main()
{
	const char* save_file_path = "C:/Users/zhiwa/OneDrive/Desktop/Linwood.xml";
	const char* save_file_path_json = "C:/Users/zhiwa/OneDrive/Desktop/Linwood.json";
	const char* test_file_path = "C:/Users/zhiwa/OneDrive/Desktop/test.json";
	std::cout << "Start to transfer IFC into XML\n";
	std::cout << "Output Location:"<<save_file_path<<"\n";

	shared_ptr<ReaderSTEP> step_reader(new ReaderSTEP());

	step_reader->xmlwriteModelToStream(L"Linwood.ifc", save_file_path, save_file_path_json);

	//boost::property_tree::ptree ptRoot;
	//boost::property_tree::read_json(save_file_path_json, ptRoot);
	//using boost::property_tree::ptree;
	//ptree::const_iterator end = ptRoot.end();
	//for (ptree::const_iterator it = ptRoot.begin(); it != end; ++it) {
	//	std::string IDvalue = it->second.get_child("Entity_ID").get_value<std::string>();
	//
	//		if ("2071" == IDvalue)
	//		{
	//			//ptree te = it->second.get_child("Parent");
	//			ptree te = it->second;
	//			//std::string s("2071");

	//			te.put("Parent", "2071");
	//			//it->second.get_child("Parent").put_value<std::string>(s);
	//			//te.put("2071", 3.14f);
	//		/*	const char* cc = "2071";
	//			std::string s("2071");
	//			std::string s1("Parent");
	//			std::pair<std::string, std::string> pairv;
	//			pairv = std::make_pair(s1, s);
	//			te.push_back(pairv);*/
	//			//te.push_back(std::make_pair(s1, s));
	//		/*	ptree::value_type fruit = 
	//			te.get_child("Parent").put_value<std::string>(s);*/
	//			//te.put("Parent", s3.str());
	//			std::cout << te.data() << std::endl;
	//			ptRoot.erase(it->first);
	//			ptRoot.put_child("BuildingEntity", te);
	//			boost::property_tree::write_json(test_file_path, ptRoot);
	//			break;
	//		}
	//
	//	//if(IDvalue == m_RelatedElements->m_entity_id)

	//	std::cout << it->first << ": " << it->second.get_value<std::string>() << std::endl;

	//	//print(it->second);
	//}
	//boost::property_tree::write_json(save_file_path_json, ptRoot);
	std::cout << "Done!\n";
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
