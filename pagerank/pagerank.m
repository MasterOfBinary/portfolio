function [pi, iter] = pagerank(H, alpha, pi0, epsilon)
% Computes the pagerank given an input hyperlink matrix, value for alpha,
% and initial pi vector. Assumes H is square and nonnegative.

% Get the number of websites
n = length(H);

e = ones(n, 1);
a = ones(n, 1);

rowsums = sum(H, 2);

for i = 1:n
    % Check if the row in H is all zeros
    if rowsums(i) > 0
        a(i) = 0;
    end
end

% Create the stochastic matrix S
S = H + 1/n * a * e';

% Create teleportation matrix
E = 1/n * (e) * (e');

% Create positive Google matrix G
G = alpha * S + (1 - alpha) * E;

pik = pi0;
pik1 = G' * pik;
iter = 0; % Number of iterations it takes

% Iterate until the norm of the matrix is below the threshold
while (norm(pik1 - pik, inf) >= epsilon)
    iter = iter + 1;
    pik = pik1;
    pik1 = (G') * pik;
    
    % Guard against iterating forever
    if iter > 100000
        fprintf('Error, reached 100,000 iterations. Consider changing the tolerance.\n');
        pik
        pik1
        break;
    end
end

pi = pik1;

end

