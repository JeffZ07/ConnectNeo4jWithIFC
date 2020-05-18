// IFC2XML.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <ifcpp/reader/ReaderSTEP.h>

int main()
{
	const char* save_file_path = "C:/Users/zhiwa/OneDrive/Desktop/ifcppout2.xml";
	std::cout << "Start to transfer IFC into XML\n";
	std::cout << "Output Location:"<<save_file_path<<"\n";

	shared_ptr<ReaderSTEP> step_reader(new ReaderSTEP());

	step_reader->xmlwriteModelToStream(L"example.ifc", save_file_path);
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
