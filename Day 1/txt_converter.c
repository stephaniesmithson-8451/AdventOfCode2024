#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int get_file_count() {
    FILE *file;
    long file_size;

    file = fopen("aoc_01.txt", "r");
    
    if (file == NULL) {
        perror("Could not open file.");
        return 1;
    }

    int c;
    int count = 0;

    for (c = getc(file); c != EOF; c = getc(file))
        if (c == '\n') {
            count = count + 1;
        }
    
    fclose(file);

    return count;
}

int compare(const void* a, const void* b) {
    if(*(int*)a == *(int*)b) return 0;
    return *(int*)a < *(int*)b ? -1 : 1;
}

int get_similarity_score(int *arr, int count, int num) {
    int appearances = 0;

    for(int i = 0; i < count; i++) {
        if(arr[i] == num)
            appearances += 1;
    }

    return appearances * num;
}

int main() {
    FILE *file;
    const int count = get_file_count();
    char *line = NULL;
    size_t len = 0;
    ssize_t read;
    int a_nums[count];
    int b_nums[count];
    int sorted_a_nums[count];
    int sorted_b_nums[count];
    int i, diff, sum, sim_score = 0;

    file = fopen("aoc_01.txt", "r");
    rewind(file);
    
    if (file == NULL) {
        perror("Could not open file.");
        return 1;
    }

    while ((read = getline(&line, &len, file)) != -1) {
        char *num_a = strtok(line, " ");
        char *num_b = strtok(NULL, " ");

        int a = atoi(num_a);
        int b = atoi(num_b);
        
        printf("\nThe chars as digits are %d and %d", a, b);
        a_nums[i] = a;
        b_nums[i] = b;
        i++;
    }

    qsort(a_nums, count, sizeof(int), compare);
    qsort(b_nums, count, sizeof(int), compare);

    for(i = 0; i < count; i++) {
        printf("\nList a digit: %d\t", a_nums[i]);
        printf("List b digit: %d", b_nums[i]);
        diff = abs(b_nums[i] - a_nums[i]);
        sum += diff;
        printf("\tDifference: %d", diff);
    }

    printf("\n\nSum: %d", sum);

    for(i = 0; i < count; i++) {
        int score = get_similarity_score(b_nums, count, a_nums[i]);
        printf("\nScore for %d: %d", a_nums[i], score);
        sim_score += score;
    }

    printf("\nFinal similarity score: %d", sim_score);
    
    fclose(file);
    if(line)
        free(line);
    exit(EXIT_SUCCESS);
}

