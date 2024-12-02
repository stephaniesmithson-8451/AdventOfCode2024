#include <iostream>
#include <sstream>
#include <fstream>
#include <string>
#include <list>
#include <vector>

std::list<std::vector<int>> get_list_of_arrays_from_file(std::string filename) {
    std::ifstream file; file.open(filename);
    std::list<std::vector<int>> reports;
    std::vector<int> report;
    std::string mystring;
    std::string line;

    while (std::getline(file, line)) {
        std::stringstream stream(line);
        int n;
        report.clear();

        std::cout << "\n" << line << std::endl;

        while (stream >> n) {
            report.push_back(n);
        }

        reports.push_back(report);
    }

    return reports;
}

std::string get_order(int a, int b) {
    if (b > a) {
        return "ASC";
    } else {
        return "DESC";
    }
}

bool check_report_is_safe(std::vector<int> report) {
    std::string order;
    int i, first_num, second_num, previous_num = 0;

    std::cout << "\n";

    for (const auto& num : report) {
        std::cout << num << ", ";

        if (i == 1) {
            first_num = num;
        } else if (i ==2) {
            second_num = num;
            order = get_order(first_num, second_num);
        }

        if (i >= 2) {
            if (order == "ASC" && num < previous_num) return false;
            if (order == "DESC" && num > previous_num) return false;
            if (num == previous_num) return false;
            if (abs(num - previous_num) > 3) return false;
        }
        
        previous_num = num;
        i++;
    }
    std::cout << "\nFirst number: " << first_num;
    std::cout << "\nSecond number: " << second_num;
    std::cout << "\nOrder: " << order << "\n";

    return true;
}

int main() {
    // Creating a list of int lists... this should be fun
    std::list<std::vector<int>> reports;
    int n_safe_reports = 0;

    reports = get_list_of_arrays_from_file("data.txt");

    std::cout << "Moving onto safety step...\n" << std::endl;

    for (const auto& report : reports) {
        bool safe = check_report_is_safe(report);
        if (safe == false) {
            std::cout << "FAILED safety check\n";
        } else {
            std::cout << "PASSED safety check\n";
            n_safe_reports++;
        }
    }

    std::cout << "\nTotal safe reports: " << n_safe_reports << std::endl;
}