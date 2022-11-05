pipeline{
    agent any
    
    tools {
        terraform 'terraform-1008'
    }
    
    stages{
        stage('Git Checkout'){
            steps {
                git branch: 'main', credentialsId: 'aa733c53-a150-4e8e-912c-1ab8d2106d36', url: 'https://github.com/JoanBency/TimeToWords'
            }
        }
        
        stage('Terraform Init'){
            steps{
                sh label: '',script: 'terraform init'
            }
        }
        
        stage('Terraform apply'){
            steps{
                echo "Terraform action from the parameter is --->${action}"
                sh label: '',script: 'terraform ${action} --auto-approve'
            }
        }
    }
}
