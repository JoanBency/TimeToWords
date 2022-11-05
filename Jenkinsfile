pipeline{
    agent any
    
    tools {
        terraform 'jenkins-terraform'
    }
    
    stages{
        stage('Git Checkout'){
            steps {
                git branch: 'main', credentialsId: '276050c6-cd1b-423b-928c-969c14f2ca17', url: 'https://github.com/JoanBency/TimeToWords'
            }
        }
        
        stage('Terraform Init'){
            steps{
                sh label: '',script: 'bash /usr/local/bin/terraform init'
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
