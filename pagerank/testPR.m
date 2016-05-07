function [mu, sigma, time] = testPR(n, beta, tests)
% Runs a number of pagerank tests using random hyperlink matrices and returns
% the mean and std dev of the number of iterations and the average time

% Initial vector
pi0 = rand(n, 1);
pi0 = pi0 / norm(pi0, 1); % Normalize it

% Total time of all tests (calculating PR)
timePR = 0;

% Total time to generate H
timeH = 0;

% Vector keeping track of the number of iterations
iters = zeros(tests, 1);

% Tolerance
epsilon = 1e-15;

% Probability of not teleporting to a random website
alpha = 0.85;

fprintf('Websites: %u, beta: %f', n, beta);

for i = 1:tests
    tstart = clock();
    % Create hyperlink matrix
    H = randomH(n, beta);
    tend = clock();
    timeH = timeH + etime(tend, tstart);
    
    % Compute pagerank
    tstart = clock();
    [~, iter] = pagerank(H, alpha, pi0, epsilon);
    iters(i) = iter;
    tend = clock();
    timePR = timePR + etime(tend, tstart);
end

% Calculate average time per test
timePR = timePR / tests;
timeH = timeH / tests;
time = timePR;

% Calculate mean, standard deviation
mu = mean(iters);
sigma = std(iters);

fprintf(', iterations: %f (SD %f), time (PR): %f sec, time (H): %f sec.\n', mu, sigma, timePR, timeH);

end

