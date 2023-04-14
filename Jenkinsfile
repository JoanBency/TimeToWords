pipeline{
    agent any
    
    stages{
        stage('Git Checkout'){
            steps {
                git branch: 'main', credentialsId: <CredentialId>, url: 'https://github.com/JoanBency/TimeToWords'
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
